#------------------------------
#
# written by zfy 12-3-2018
#------------------------------

#--imports---------------------
import os
import tensorflow as tf
from tools.setting import *
from tools.dataset_maintainer import get_set
from 

import CNNinference

#--training parameters---------
BATCH_SIZE = 100
LEARNING_RATE_BASE = 0.8
LEARNING_RATE_DECAY = 0.99
REGULIZATION_RATE = 0.0001
TRAINING_STEPS = 30000
MOVING_AVERAGE_DECAY = 0.99
MODEL_SAVE_PATH = 'models/'
MODEL_NAME = 'model.ckpt'

#--helper function-------------


#--trian-----------------------
def train(data):
    x = tf.placeholder(tf.float32, [None, inference.INPUT_NODE], name = 'x-input')
    y_ = tf.placeholder(tf.float32, [None, inference.OUTPUT_NODE], name = 'y-input')

    regulizer = tf.contrib.layers.l2_regularizer(REGULIZATION_RATE)
    y = CNNinference.inference(x, regulizer)
    global_step = tf.Variable(0, trainable = False)

    variable_averages = tf.trian.ExponentialMovingAverage(MOVING_AVERAGE_DECAY, global_step)
    variables_averages_op = variable_averages.apply(tf.trainable_variables())
    cross_entropy = tf.nn.sparse_softmax_cross_entropy_with_logits(logits = y, labels = tf.argmax(y_, 1))
    cross_entropy_mean = tf.reduce_mean(cross_entropy)
    loss = cross_entropy_mean + tf.add_n(tf.get_collection('losses'))
    learning_rate = tf.train.exponential_decay(LEARNING_RATE_BASE, global_step,
                                               mnist.train.num_examples / BATCH_SIZE,
                                               LEARNING_RATE_DECAY)
    train_step = tf.train.GradiantDescentOptimizer(learning_rate).minimize(loss, global_step = global_step)
    with tf.control_dependencies([train_step, variables_averages_op]):
        train_op = tf.no_op(name = 'train')

    saver = tf.train.Saver()

    with tf.Session() as sess:
        tf.global_variables_initializer().run()

    for i in range(TRAINING_STEPS):
        xs, ys = mnist.train.next_batch(BATCH_SIZE)
        _, loss_value, step = sess.run([train_op, loss, global_step], feed_dict = {x: xs, y_: ys})

        if 0 == i % 1000:
            print("After {} training steps, loss is {}".format(i, loss_value))
            saver.save(sess, os.path.join(MODEL_SAVE_PATH, MODEL_NAME), global_step = global_step)
    return None

#--main------------------------
def main(argv=None):
    mnist = input_data.read_data_sets("/tmp/data", one_hot = "true")
    train(mnist)

if __name__ == '__main__':
    tf.app.run()
