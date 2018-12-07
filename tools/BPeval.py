#------------------------------
# 
# written by zfy 12-07-2018
#------------------------------

#--imports---------------------
import tensorflow as tf
from dataset_maintainer import get_set
from BPinference import inference
from time import time
from os import system
from BPtrain import *

#--variables-------------------
EVAL_INTERVAL_SECS = 20

#--evaluation
def evaluation():
    INPUT_NODE = len(testset[0][0])
    OUTPUT_NODE = len(testset[0][1])

    with tf.Graph().as_default() as g:
        x = tf.placeholder(tf.float32, [None, INPUT_NODE], name = 'x-input')
        y_ = tf.placeholder(tf.float32, [None, OUTPUT_NODE], name = 'y-input')
        testset = get_set('validate')

        y = inference(x, None, )
        
        correct_prediction = tf.equal(tf.argmax(y, 1), tf.aargmax(y_, 1))
        accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))

        variable_averages = tf.train.ExponentialMovingAverage(MOVING_AVERAGE_DECAY)
        variables_to_restore = variable_averages.variables_to_restore()
        saver = tf.train.Saver(variables_to_restore)

        while True:
            with tf.Session() as sess:
                ckpt = tf.train.get_checkpoitn_state(MODEL_SAVE_PATH)
                if ckpt and ckpt.modle_checkpoint_path:
                    saver.restore(sess, ckpt.model_checkpoint_path)
                    global_step = ckpt.model_checkpoint_path.split('/')[-1].splite('-')[-1]
                    accuracy_score = sess.run(accuracy, feed_dict = {x: [a[0] for a in testset], y_: [a[1] for a in testset]})
                    print("After {} training step, accuracy = {}".format(global_step, accuracy_score))
                sleep(EVAL_INTERVAL_SECS)

    return None