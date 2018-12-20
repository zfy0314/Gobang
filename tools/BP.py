#------------------------------
# 
# written by zfy 12-07-2018
#------------------------------

#--imports---------------------
from __future__ import print_function
import tensorflow as tf
import numpy as np
from dataset_maintainer import get_set
from time import time
from time import sleep
from os import system
from os import listdir
from raw2dataset import zfy_timer
from raw2dataset import autowrite
from raw2dataset import zfy_xy2linear
from raw2dataset import zfy_linear2xy
from raw2dataset import zfy_sequence2board
from raw2dataset import zfy_expand
from raw2dataset import zfy_board2sequence
from setting import *

#--global variables------------
HLAYERS = [512, 512, 512, 512, 512, 512]
BATCH_SIZE_MIN = 50
BATCH_RATIO = 0.002
TRAINING_STEPS = 1
TRAINSET_RATIO = 0.9
CHECKPOINT_INTERVAL = 100

LEARNING_RATE_BASE = 1.8
LEARNING_RATE_DECAY =  0.993
REGULARIZATION_RATE = 0.0001
MOVING_AVERAGE_DECAY = 0.99

#--train-----------------------
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


def train(name):
    testset = get_set('validate')
    DATA_NUM = len(testset)
    INPUT_NODE = len(testset[0][0])
    OUTPUT_NODE = len(testset[0][1])
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
    
    y = inference(x, None, weights)
    y_average = inference(x, variable_averages, weights)

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

    correct_prediction = tf.equal(tf.argmax(y_average, 1), tf.argmax(y_, 1))
    accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))

    saver = tf.train.Saver()

    with tf.Session() as sess:
        tf.global_variables_initializer().run()
        timer = zfy_timer('reset')
        for i in range(TRAINING_STEPS + 1):
            dataset = get_set('train{}'.format(i%int(1//BATCH_RATIO)))
            print(dataset[0])
            sess.run(train_op, feed_dict={x: [a[0] for a in dataset], y_: [a[1] for a in dataset]})
            if 0 == i % CHECKPOINT_INTERVAL:
                validate_acc = sess.run(accuracy, feed_dict={x: [a[0] for a in testset], y_: [a[1] for a in testset]})
                lss = sess.run(loss, feed_dict={x: [a[0] for a in dataset], y_: [a[1] for a in dataset]})
                with open('models/{name}/{name}.acc'.format(name=name), 'a+') as fout:
                    fout.write('{}: {}\n'.format(i, validate_acc))
                with open('models/{name}/{name}.lss'.format(name=name), 'a+') as fout:
                    fout.write('{}: {}\n'.format(i, lss))
                print('saving {} steps model, accuracy = {}, loss = {}, time used = {}'.format(i, validate_acc, lss, zfy_timer(timer)))
                #saver.save(sess, "models/{name}/{name}.ckpt-{stp}".format(name=name, stp=i))
                timer = zfy_timer('reset')    
        

        saver.save(sess, "models/{name}/{name}.ckpt-{stp}".format(name=name, stp=TRAINING_STEPS))

        while True:
            print('new game started')
            board = [0 for i in range(BOARD_SIZE ** 2)]
            next_step = 0
            steps = []
            while True:
                #print(board)
                bp_result = sess.run(y, feed_dict={x:[tuple(board)]}).tolist()
                
                #print(bp_result)
                board[bp_result[0].index(max(bp_result[0]))] = 1
                steps.append(zfy_linear2xy(bp_result[0].index(max(bp_result[0]))))
                for i in range(BOARD_SIZE):
                    for j in range(BOARD_SIZE):
                        print(board[i * 19 + j], end=' ')
                    print('')
                print(steps[-1])
                x = int(input('next_step_x: '))
                if x > BOARD_SIZE:
                    del steps[-1]
                    print('game ended')
                    break
                y = int(input('next_step_y: '))
                if y > BOARD_SIZE:
                    del steps[-1]
                    print('game ended')
                    break
                next_step = [x, y]
                steps.append(next_step)
                board[zfy_xy2linear(next_step)] = 2
                x = [i[0] for i in steps]
                y = [i[1] for i in steps]
            temp = zfy_sequence2board(steps)[min(x):max(x)+1][min(y):max(y)+1]
            boards = zfy_expand(temp)
            for brd in boards: autowrite(zfy_board2sequence(brd), 'interaction')
            print('saved into dataset')
    return None
'''
def get_result(name, input_tensor):

    x = tf.placeholder(tf.float32, [None, len(input_tensor)], name='x-input')
    y_ = tf.placeholder(tf.float32, [None, len(input_tensor)], name='y-input')

    weights  = [[], []]
    for i in range(len(LAYER) - 1):
         weights[0].append(tf.Variable(tf.truncated_normal([LAYER[i], LAYER[i+1]], stddev=0.1)))
         weights[1].append(tf.Variable(tf.constant(1.0, shape=[LAYER[i+1]])))
    
    y = inference(x, None, weights)
    result = tf.argmax(y, 1)

    saver = tf.train.Saver(varaibles_to_restore)
    with tf.Session() as sess:
        ckpt = tf.train.get_checkpoint_state("models/{name}/".format(name = name))
        saver.restore(sess, ckpt.model_checkpoint_path)
    
    return result
'''
def main(argv = None):
    
    timestamp = "BP" + str(int(time()))
    system('mkdir models/{}'.format(timestamp))
    with open('models/{name}/{name}-spec.txt'.format(name=timestamp), 'w') as fout:
        fout.write('HLAYERS = {}\nBATCH_SIZE_MIN = {}\nBATCH_RATIO = {}\nTRAINING_STEPS = {}\nTRAINSET_RATIO = {}\nLEARNING_RATE_BASE = {}\nLEARNING_RATE_DECAY =  {}\nREGULARIZATION_RATE = {}\nMOVING_AVERAGE_DECAY = {}'.format(
            HLAYERS, BATCH_SIZE_MIN, BATCH_RATIO, TRAINING_STEPS, TRAINSET_RATIO, LEARNING_RATE_BASE, LEARNING_RATE_DECAY, REGULARIZATION_RATE, MOVING_AVERAGE_DECAY))
    print('models path created')
    train(timestamp)
    
    

if __name__ == '__main__':
    main()