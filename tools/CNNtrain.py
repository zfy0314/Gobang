#------------------------------
#
# written by zfy 12-3-2018
#------------------------------

#--imports---------------------
import os
import tensorflow as tf
from setting import *
from dataset_maintainer import get_set
from raw2dataset import zfy_timer

import CNNinference

#--training parameters---------
BATCH_SIZE = 100
LEARNING_RATE_BASE = 0.8
LEARNING_RATE_DECAY = 0.99
REGULIZATION_RATE = 0.0001
TRAINING_STEPS = 300000
MOVING_AVERAGE_DECAY = 0.99
MODEL_SAVE_PATH = 'models/'
MODEL_NAME = 'model.ckpt'

#--helper function-------------
def zfy_data2board(data):
    result = []
    for i in range(BOARD_SIZE):
        result.append(data[i * BOARD_SIZE:(i + 1) * BOARD_SIZE - 1])
    return tuple(result)

#--trian-----------------------
def train():
    dataset = get_set('train')
    DATA_NUM = len(dataset)

    x = tf.placeholder(tf.float32, [None, CNNinference.BOARD_SIZE, CNNinference.BOARD_SIZE, CNNinference.NUM_CHANNELS], name = 'x-input')
    y_ = tf.placeholder(tf.float32, [None, CNNinference.OUTPUT_NODE], name = 'y-input')

    regulizer = tf.contrib.layers.l2_regularizer(REGULIZATION_RATE)
    y = CNNinference.inference(x, regulizer)
    global_step = tf.Variable(0, trainable = False)

    variable_averages = tf.trian.ExponentialMovingAverage(MOVING_AVERAGE_DECAY, global_step)
    variables_averages_op = variable_averages.apply(tf.trainable_variables())
    cross_entropy = tf.nn.sparse_softmax_cross_entropy_with_logits(logits = y, labels = tf.argmax(y_, 1))
    cross_entropy_mean = tf.reduce_mean(cross_entropy)
    loss = cross_entropy_mean + tf.add_n(tf.get_collection('losses'))
    learning_rate = tf.train.exponential_decay(LEARNING_RATE_BASE, global_step,
                                               DATA_NUM / BATCH_SIZE,
                                               LEARNING_RATE_DECAY)
    train_step = tf.train.GradiantDescentOptimizer(learning_rate).minimize(loss, global_step = global_step)
    with tf.control_dependencies([train_step, variables_averages_op]):
        train_op = tf.no_op(name = 'train')

    saver = tf.train.Saver()

    with tf.Session() as sess:
        tf.global_variables_initializer().run()
        timer = zfy_timer('reset')
        for i in range(TRAINING_STEPS):
            start = int((i * BATCH_SIZE) % DATA_NUM)
            end = int(min(start + BATCH_SIZE, DATA_NUM))
            _, loss_value, step = sess.run([train_op, loss, global_step], feed_dict = {x: [zfy_data2board(a[0]) for a in dataset[start:end]], y_: [a[1] for a in dataset[start:end]]})

            if 0 == i % 1000:
                print("After {} training steps, loss is {}".format(i, loss_value))
                saver.save(sess, os.path.join(MODEL_SAVE_PATH, MODEL_NAME), global_step = global_step)
                print('{} used'.format(zfy_timer(timer)))
                timer = zfy_timer('reset')
    return None

#--main------------------------
def main(argv=None):
    
    train()

if __name__ == '__main__':
    tf.app.run()
