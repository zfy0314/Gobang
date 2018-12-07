#------------------------------
# 
# written by zfy 12-07-2018
#------------------------------

#--imports---------------------
import tensorflow as tf
import numpy as np
from dataset_maintainer import get_set
from BPinference import inference
from time import time
from os import system

#--global variables------------
HLAYERS = [512, 512, 512, 512, 512]
BATCH_SIZE_MIN = 50
BATCH_RATIO = 0.01 
TRAINING_STEPS = 1000000
TRAINSET_RATIO = 0.8

LEARNING_RATE_BASE = 0.7
LEARNING_RATE_DECAY =  0.8
REGULARIZATION_RATE = 0.0001
MOVING_AVERAGE_DECAY = 0.99

#--train-----------------------
def train(name):
    dataset = get_set('train')
    testset = get_set('validate')
    DATA_NUM = len(dataset)
    INPUT_NODE = len(dataset[0][0])
    OUTPUT_NODE = len(dataset[0][1])
    LAYER = [INPUT_NODE] + HLAYERS + [OUTPUT_NODE]
    BATCH_SIZE = max(BATCH_SIZE_MIN, int(BATCH_RATIO*DATA_NUM))

    x = tf.placeholder(tf.float32, [None, INPUT_NODE], name='x-input')
    y_ = tf.placeholder(tf.float32, [None, OUTPUT_NODE], name='y-input')

    weights  = [[], []]
    for i in range(len(LAYER) - 1):
         weights[0].append(tf.Variable(tf.truncated_normal([LAYER[i], LAYER[i+1]], stddev=0.1)))
         weights[1].append(tf.Variable(tf.constant(1.0, shape=[LAYER[i+1]])))
    
    global_step = tf.Variable(0, trainable=False)

    variable_averages = tf.train.ExponentialMovingAverage(MOVING_AVERAGE_DECAY, global_step)
    variable_averages_op = variable_averages.apply(tf.trainable_variables())
    
    #y = inference(x, None, weights)
    y = inference(x, variable_averages, weights)

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

    correct_prediction = tf.equal(tf.argmax(y, 1), tf.argmax(y_, 1))
    accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))

    saver = tf.train.Saver()

    with tf.Session() as sess:
        tf.global_variables_initializer().run()
        for i in range(TRAINING_STEPS):
            start = int((i * BATCH_SIZE) % DATA_NUM)
            end = int(min(start+BATCH_SIZE, DATA_NUM))
            sess.run(train_op, feed_dict={x: [a[0] for a in dataset[start:end]], y_: [a[1] for a in dataset[start:end]]})
            print("trained {num} steps".format(num=i))
            validate_acc = sess.run(accuracy, feed_dict={x: [a[0] for a in testset], y_: [a[1] for a in testset]})
            with open('models/{name}/{name}.acc'.format(name=name), 'a+') as fout:
                fout.write('{}: {}\n'.format(i, validate_acc))
            print('step {} check, accuracy = {}'.format(i, validate_acc))
            if 0 == i % 1000:
                print('saving {} steps model'.format(i))
                saver.save(sess, "models/{name}/{name}-{stp}".format(name=name, stp=i))
    return None

def main(argv = None):
    timestamp = str(time())
    system('mkdir models/{}'.format(timestamp))
    print('models path created')
    train(timestamp)
    return None

if __name__ == '__main__':
    main()