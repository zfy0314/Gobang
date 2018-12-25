#------------------------------
# CNN
# written by zfy 12-17-2018
#------------------------------

import tensorflow as tf
from helpers import *
from settings import *

INPUT_NODE = BOARD_SIZE ** 2
OUTPUT_NODE = INPUT_NODE
NUM_CHANNELS = 1
NUM_LABELS = OUTPUT_NODE

CONV1_DEEP = 16
CONV1_SIZE = 3
CONV2_DEEP = 24
CONV2_SIZE = 3
CONV3_DEEP = 32
CONV3_SIZE = 3
FC_SIZE = 512

BATCH_RATIO = 0.002
TRAINING_STEPS = 100000
CHECKPOINT_INTERVAL = 100
SAVER_INTERVAL = 20

LEARNING_RATE_BASE = 1.8
LEARNING_RATE_DECAY =  0.997
REGULARIZATION_RATE = 0.0001
MOVING_AVERAGE_DECAY = 0.99

def inference(input_tensor, regularizer):
    with tf.variable_scope('layer1-conv1'):
        conv1_weights = tf.get_variable('weight', [CONV1_SIZE, CONV1_SIZE, NUM_CHANNELS, CONV1_DEEP],
                                        initializer = tf.truncated_normal_initializer(stddev = 0.1))
        conv1_biases = tf.get_variable('bias', [CONV1_DEEP], initializer = tf.constant_initializer(0.0))
        conv1 = tf.nn.conv2d(input_tensor, conv1_weights, strides = [1, 1, 1, 1], padding = 'VALID')
        relu1 = tf.nn.relu(tf.nn.bias_add(conv1, conv1_biases))

    with tf.variable_scope('layer2-conv2'):
        conv2_weights = tf.get_variable('weight', [CONV2_SIZE, CONV2_SIZE, CONV1_DEEP, CONV2_DEEP],
                                        initializer = tf.truncated_normal_initializer(stddev = 0.1))
        conv2_biases = tf.get_variable('bias', [CONV2_DEEP], initializer = tf.constant_initializer(0.0))
        conv2 = tf.nn.conv2d(relu1, conv2_weights, strides = [1, 2, 2, 1], padding = 'VALID')
        relu2 = tf.nn.relu(tf.nn.bias_add(conv2, conv2_biases))

    with tf.variable_scope('layer3-conv3'):
        conv3_weights = tf.get_variable('weight', [CONV3_SIZE, CONV3_SIZE, CONV2_DEEP, CONV3_DEEP],
                                        initializer = tf.truncated_normal_initializer(stddev = 0.1))
        conv3_biases = tf.get_variable('bias', [CONV3_DEEP], initializer = tf.constant_initializer(0.0))
        conv3 = tf.nn.conv2d(relu2, conv3_weights, strides = [1, 2, 2, 1], padding = 'VALID')
        relu3 = tf.nn.relu(tf.nn.bias_add(conv3, conv3_biases))

    cnn_out = relu3
    shape = cnn_out.get_shape().as_list()
    nodes = shape[1] * shape[2] * shape[3]
    reshaped = tf.reshape(cnn_out,[-1, nodes])

    with tf.variable_scope('layer4-fc1'):
        fc1_weights = tf.get_variable('weight', [nodes, FC_SIZE],
                                      initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc1_weights))
        fc1_biases = tf.get_variable('bias', [FC_SIZE], initializer = tf.constant_initializer(0.1))
        fc1 = tf.nn.relu(tf.matmul(reshaped, fc1_weights) + fc1_biases)

    with tf.variable_scope('layer6-fc3'):
        fc3_weights = tf.get_variable('weight', [FC_SIZE, FC_SIZE],
                                      initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc3_weights))
        fc3_biases = tf.get_variable('bias', [FC_SIZE], initializer = tf.constant_initializer(0.1))
        fc3 = tf.nn.relu(tf.matmul(fc1, fc3_weights) + fc3_biases)

    with tf.variable_scope('layer5-fc2'):
        fc2_weights = tf.get_variable('weight', [FC_SIZE, OUTPUT_NODE],
                                      initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc2_weights))
        fc2_biases = tf.get_variable('bias', [OUTPUT_NODE], initializer = tf.constant_initializer(0.1))
        output = tf.nn.relu(tf.matmul(fc3, fc2_weights) + fc2_biases)

    return output

def train(name):
    x = tf.placeholder(tf.float32, [None, BOARD_SIZE, BOARD_SIZE, NUM_CHANNELS], name = 'x-input')
    y_ = tf.placeholder(tf.float32, [None, OUTPUT_NODE], name = 'y-input')

    regularizer = tf.contrib.layers.l2_regularizer(REGULARIZATION_RATE)
    y = inference(x, regularizer)
    global_step = tf.Variable(0, trainable = False)

    variable_averages = tf.train.ExponentialMovingAverage(MOVING_AVERAGE_DECAY, global_step)
    variable_averages_op = variable_averages.apply(tf.trainable_variables())
    cross_entropy = tf.nn.sparse_softmax_cross_entropy_with_logits(logits = y, labels = tf.argmax(y_, 1))
    cross_entropy_mean = tf.reduce_mean(cross_entropy)
    loss = cross_entropy_mean + tf.add_n(tf.get_collection('losses'))
    learning_rate = tf.train.exponential_decay(LEARNING_RATE_BASE, global_step,
                                             BATCH_RATIO, LEARNING_RATE_DECAY)
    train_step = tf.train.GradientDescentOptimizer(learning_rate).minimize(loss, global_step = global_step)
    with tf.control_dependencies([train_step, variable_averages_op]):
        train_op = tf.no_op(name = 'train')

    saver = tf.train.Saver()
    
    with tf.Session() as sess:
        tf.global_variables_initializer().run()
        timer = zfy_timer('reset')
        
        for i in range(TRAINING_STEPS + 1):
            
            dataset = zfy_getset('train{}'.format(i%int(1//BATCH_RATIO)))
            train_feed = {x: [zfy_data2board(data[0]) for data in dataset], y_: [data[1] for data in dataset]}
            _, loss_value, step = sess.run([train_op, loss, global_step], feed_dict = train_feed)
            print('step {}: loss = {}, time used {} seconds'.format(i, loss_value, zfy_timer(timer)))
            timer = zfy_timer('reset')
            with open(PATH_TO_MODELS_CNN + FILE_CNN_LOSS, 'a+') as fout:
                fout.write('{}: {}\n'.format(i, loss_value))
            #if 0 == i % CHECKPOINT_INTERVAL:
                #print(evaluate(True))
            if 0 == i % SAVER_INTERVAL:
                saver.save(sess, PATH_TO_MODELS_CNN + name + '.ckpt', global_step = step)
                acc = evaluate()
                print('step {}: accuracy = {}'.format(i, acc))
                with open(PATH_TO_MODELS_CNN + FILE_CNN_ACCURACY, 'a+') as fout:
                    fout.write('{}: {}\n'.format(i, acc))
                
    return None
    
def evaluate():
    with tf.Graph().as_default() as g:
        x = tf.placeholder(tf.float32, [None, BOARD_SIZE, BOARD_SIZE, NUM_CHANNELS], name = 'x-input')
        y_ = tf.placeholder(tf.float32, [None, OUTPUT_NODE], name = 'y-input')
        y = inference(x, None)
        prediction = tf.argmax(y, 1)
        prediction_correct = tf.equal(prediction, tf.argmax(y_, 1))
        accuracy = tf.reduce_mean(tf.cast(prediction_correct, tf.float32))
        variable_averages = tf.train.ExponentialMovingAverage(MOVING_AVERAGE_DECAY)
        variables_to_restore = variable_averages.variables_to_restore()
        saver = tf.train.Saver(variables_to_restore)

        with tf.Session() as sess:
            testset = zfy_getset('validate')
            test_feed = {x: [zfy_data2board(data[0]) for data in testset], y_: [data[1] for data in testset]}
            ckpt = tf.train.get_checkpoint_state(PATH_TO_MODELS_CNN)
            saver.restore(sess, ckpt.model_checkpoint_path)
            global_step = ckpt.model_checkpoint_path.split('-')[-1]
            score = sess.run(accuracy, feed_dict = test_feed)
    return score

def play(board):
    with tf.Graph().as_default() as g:
        x = tf.placeholder(tf.float32, [None, BOARD_SIZE, BOARD_SIZE, NUM_CHANNELS], name = 'x-input')
        y = inference(x, None)
        prediction = tf.argmax(y, 1)
        variable_averages = tf.train.ExponentialMovingAverage(MOVING_AVERAGE_DECAY)
        variables_to_restore = variable_averages.variables_to_restore()
        saver = tf.train.Saver(variables_to_restore)

        with tf.Session() as sess:
            ckpt = tf.train.get_checkpoint_state(PATH_TO_MODELS_CNN)
            saver.restore(sess, ckpt.model_checkpoint_path)
            result = sess.run(prediction, feed_dict = {x: [board]})
    return result

def main(argv = None):
    #zfy_getset(None)
    train('model')
    result = evaluate()
    print('after training {} steps: accuracy = {}'.format(TRAINING_STEPS, result))
    return None
    
if __name__ == '__main__':
    main()