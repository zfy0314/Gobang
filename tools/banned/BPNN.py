#------------------------------
# gobang using BPNN
# written by zfy 12-04-2018
#------------------------------

#--imports---------------------
import tensorflow as tf
from time import time
from os import system
from tools.setting import *
from tools.dataset_maintainer import get_set

#--BP settings-----------------
HLAYERS = [512, 512, 512, 512, 512]
BATCH_SIZE_MIN = 20
BATCH_RATIO = 0.01 
TRAINING_STEPS = 1000000
TRAINSET_RATIO = 0.8

LEARNING_RATE_BASE = 0.003
LEARNING_RATE_DECAY =  0.8
REGULARIZATION_RATE = 0.0001
MOVING_AVERAGE_DECAY = 0.99

def get_data():
    return None

def inference(input_tensor, avg_class, weights):
    if None == avg_class:
        '''
        layer1 = tf.nn.relu(tf.matmul(input_tensor, weights1) + biases1)
        return tf.matmul(layer1, weights2) + biases2
        '''
        output_tensor = tf.nn.relu(tf.matmul(input_tensor, weights[0][0]) + weights[1][0])
        for i in range(1, len(weights) - 1):
            output_tensor = tf.nn.relu(tf.matmul(output_tensor, weights[0][i]) + weights[1][i])
        return tf.matmul(output_tensor, weights[0][-1]) + weights[1][-1]
    else:
        '''
        layer1 = tf.nn.relu(tf.matmul(input_tensor, avg_class.average(weights1)) + avg_class.average(biases1))
        return tf.matmul(layer1, avg_class.average(weights2)) + avg_class.average(biases2)
        '''
        output_tensor = tf.nn.relu(tf.matmul(input_tensor, avg_class.average(weights[0][0])) + avg_class.average(weights[1][0]))
        for i in range(1, len(weights) - 1):
            output_tensor = tf.nn.relu(tf.matmul(output_tensor, avg_class.average(weights[0][i])) + avg_class.average(weights[1][i]))
        return tf.matmul(output_tensor, avg_class.average(weights[0][-1])) + avg_class.average(weights[1][-1])

def zfy_bp(name):
    
    DATA_NUM = len(dataset)
    INPUT_NODE = len(dataset[0][0])
    OUTPUT_NODE = len(dataset[0][1])
    LAYER = [INPUT_NODE] + HLAYERS + [OUTPUT_NODE]
    BATCH_SIZE = min(BATCH_SIZE_MIN, BATCH_RATIO*DATA_NUM)

    x = tf.placeholder(tf.float32, [None, INPUT_NODE], name='x-input')
    y_ = tf.placeholder(tf.float32, [None, OUTPUT_NODE], name='y-input')

    '''
    weights1 = tf.Variable(tf.truncated_normal([INPUT_NODE, LAYER1_NODE], stddev=0.1))
    biases1 = tf.Variable(tf.constant(0.1, shape=[LAYER1_NODE]))
    weights2 = tf.Variable(tf.truncated_normal([LAYER1_NODE, OUTPUT_NODE], stddev=0.1))
    biases2 = tf.Variable(tf.constant(0.1, shape=[OUTPUT_NODE]))
    '''

    weights  = [[], []]
    for i in range(len(LAYER) - 1):
         weights[0].append(tf.Variable(tf.truncated_normal([LAYER[i], LAYER[i+1]], stddev=0.1)))
         weights[1].append(tf.Variable(tf.constant(1.0, shape=[LAYER[i+1]])))
    
    y = inference(x, None, weights)

    global_step = tf.Variable(0, trainable=False)

    variable_averages = tf.train.ExponentialMovingAverage(MOVING_AVERAGE_DECAY, global_step)
    variable_averages_op = variable_averages.apply(tf.trainable_variables())

    average_y = inference(x, variable_averages, weights)

    cross_entropy = tf.nn.sparse_softmax_cross_entropy_with_logits(logits=y, labels=tf.argmax(y_, 1))
    cross_entropy_mean = tf.reduce_mean(cross_entropy)
    regularizer = tf.contrib.layers.l2_regularizer(REGULARIZATION_RATE)
    regularization = 0
    for i in range(len(weights)):
        regularization = regularization + regularizer(weights[0][i])
    loss = cross_entropy_mean + regularization
    
    learning_rate = tf.train.exponential_decay(LEARNING_RATE_BASE, global_step, DATA_NUM / BATCH_SIZE, LEARNING_RATE_DECAY)

    train_step = tf.train.GradientDescentOptimizer(learning_rate).minimize(loss, global_step=global_step)

    with tf.control_dependencies([train_step, variable_averages_op]):
        train_op = tf.no_op(name='train')

    correct_prediction = tf.equal(tf.argmax(average_y, 1), tf.argmax(y_, 1))
    accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))

    saver = tf.train.Saver()

    with tf.Session() as sess:
        tf.global_variables_initializer().run()
        testset = dataset[int(DATA_NUM*TRAINSET_RATIO):-1]
        trainset = dataset[0:int(DATA_NUM*TRAINSET_RATIO)]
        X, Y = [a[0] for a in testset], [a[1] for a in testset]
        print(type(X))
        test_feed = {x: X[0:-1], y_: Y[0:-1]}

        for i in range(TRAINING_STEPS):
            validate_acc = sess.run(accuracy, feed_dict=test_feed)
            print("after {num} training steps, validation accuracy using average model is {acc}".format(num=i, acc=validate_acc))

            start = (i * BATCH_SIZE) % int(DATA_NUM*TRAINSET_RATIO)
            end = min(start+BATCH_SIZE, int(DATA_NUM*TRAINSET_RATIO))
            sess.run(train_op, feed_dict={x: [a[0] for a in trainset[start:end]], y_: [a[1] for a in trainset[start:end]]})
            if 0 == i % 1000:
                saver.save(sess, "{name}/{name}-{stp}".format(name=name, stp=i, t=int(time())))
            with open("{name}/{name}.acc".format(name=name), "a+") as f:
                f.write("{acc}\n".format(stp=i, t=int(time()), acc=validate_acc))