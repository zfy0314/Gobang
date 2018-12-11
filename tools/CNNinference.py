#------------------------------
#
# written by zfy 12-02-2018
#------------------------------

#--imports---------------------
import tensorflow as tf
from setting import *

#--parameter of NN-------------
INPUT_NODE = BOARD_SIZE ** 2
OUTPUT_NODE = BOARD_SIZE ** 2

IMAGE_SIZE = BOARD_SIZE
NUM_CHANNELS = 1
NUM_LABELS = OUTPUT_NODE

LAYERS = [['conv', 3, 16, [1, 1, 1, 1]],
          ['conv', 3, 32, [1, 1, 1, 1]],
          ['conv', 5, 32, [1, 2, 2, 1]],
          ['fc', 512],
          ]

'''
CONV1_DEEP = 32
CONV1_SIZE = 5
CONV2_DEEP = 64
CONV2_SIZE = 5
FC_SIZE = 512
'''

def inference(input_tensor, regularizer):
    layer = LAYERS[0]
    layer_type = layer[0]
    if 'conv' == layer_type:
        conv_size = layer[1]
        conv_depth = layer[2]
        conv_stride = layer[3]
        with tf.variable_scope('layer0-conv'):
            conv_weights = tf.get_variable('weights', [conv_size, conv_size, NUM_CHANNELS, conv_depth],
                                           initializer = tf.truncated_normal_initializer(stddev = 0.1))
            conv_biases = tf.get_variable('bias', [conv_depth], initializer = tf.constant_initializer(0.1))
            result = tf.nn.conv2d(input_tensor, conv_weights, strides = conv_stride, padding = 'VALID')
            output = tf.nn.relu(tf.nn.bias_add(result, conv_biases))
    if 'fc' == layer_type:
        shape = input_tensor.get_shape().as_list()
        nodes = shape[1] * shape[2] * shape[3]
        reshaped = tf.reshape(input_tensor, [shape[0], nodes])
        fc_size = layer[1]
        with tf.variable_scope('layer0-fc'):
            fc_weights = tf.get_variable('weights', [nodes, fc_size],
                                         initializer = tf.truncated_normal_initializer(stddev = 0.1))
            if not None == regularizer:
                tf.add_to_collection('losses', regularizer(fc_weights))
            fc_biases = tf.get_variable('biases', [fc_size],
                                        initializer = tf.constant_initializer(0.1))
            output = tf.nn.relu(tf.matmul(reshaped, fc_weights) + fc_biases)

    for i in range(1, len(LAYERS)):
        layer = LAYERS[i]
        layer_type = layer[0]
        if 'conv' == layer_type:
            conv_size = layer[1]
            conv_depth = layer[2]
            conv_stride = layer[3]
            conv_depth_pre = LAYERS[i - 1][2]
            with tf.variable_scope('layer{}-conv'.format(i)):
                conv_weights = tf.get_variable('weights', [conv_size, conv_size, conv_depth_pre, conv_depth],
                                               initializer = tf.truncated_normal_initializer(stddev = 0.1))
                conv_biases = tf.get_variable('biases', [conv_depth], initializer = tf.constant_initializer(0.1))
                result = tf.nn.conv2d(output, conv_weights, strides = conv_stride, padding = 'VALID')
                output = tf.nn.relu(tf.nn.bias_add(result, conv_biases))
        if 'fc' == layer_type:
            shape = output.get_shape().as_list()
            nodes = shape[1] * shape[2] * shape[3]
            reshaped = tf.reshape(output, [shape[0], nodes])
            fc_size = layer[1]
            with tf.variable_scope('layer{}-fc'.format(i)):
                fc_weights = tf.get_variable('weights', [nodes, fc_size],
                                          initializer = tf.truncated_normal_initializer(stddev = 0.1))
                if not None == regularizer:
                    tf.add_to_collection('losses', regularizer(fc_weights))
                fc_biases = tf.get_variable('weights', [fc_size], initializer = tf.constant_initializer(0.1))
                output = tf.nn.relu(tf.matmul(output, fc_weights) + fc_biases)

    return output

'''
def inference(input_tensor, train, regularizer):
    with tf.variable_scope('layer1-conv1'):
        conv1_weights = tf.get_variable("weights", [CONV1_SIZE, CONV1_SIZE, NUM_CHANNELS, CONV1_DEEP],
                                        initializer = tf.truncated_normal_initializer(stddev = 0.1))
        conv1_biases = tf.get_variable("bias", [CONV1_DEEP], initializer = tf.constant_initializer(0.1))
        conv1 = tf.nn.conv2d(input_tensor, conv1_weights, strides = [1, 1, 1, 1], padding = 'VALID')
        relu1 = tf.nn.relu(tf.nn.bias_add(conv1, conv1_biases))

    with tf.name_scope('layer2-pool1'):
        pool1 = tf.nn.max_pool(relu1, ksize = [1, 2, 2, 1], strides = [1, 2, 2, 1], padding = 'VALID')
   
    with tf.variable_scope('layer3-conv2'):
        conv2_weights = tf.get_variable("weights", [CONV2_SIZE, CONV2_SIZE, CONV1_DEEP, CONV2_DEEP],
                                        initializer = tf.truncated_normal_initializer(stddev = 0.1))
        conv2_biases = tf.get_variable("bias", [CONV2_DEEP], initializer = tf.constant_initializer(0.1))
        conv2 = tf.nn.conv2d(pool1, conv2_weights, strides = [1, 1, 1, 1], padding = 'VALID')
        relu2 = tf.nn.relu(tf.nn.bias_add(conv2, conv2_biases))

    with tf.name_scope('layer4-pool2'):
        pool2 = tf.nn.max_pool(relu2, ksize = [1, 2, 2, 1], strides = [1, 2, 2, 1], padding = 'VALID')

    pool_shape = pool2.get_shape().as_list()
    nodes = pool_shape[1] * pool_shape[2] * pool_shape[3]
    reshaped = tf.reshape(pool2, [pool_shape[0], nodes])

    with tf.variable_scope('layer5-fc1'):
        fc1_weights = tf.get_variable("weights", [nodes, FC_SIZE],
                                      initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc1_weights))
        fc1_biases = tf.get_variable("biases", [FC_SIZE],
                                     initializer = tf.truncated_normal_initializer(stddev = 0.1))
        fc1 = tf.nn.relu(tf.matmul(reshaped, fc1_weights) + fc1_biases)
        if train: fc1 = tf.nn.dropout(fc1, 0.5)

    with tf.variable_scope('layer6-fc2'):
        fc2_weights = tf.get_variable("weights", [FC_SIZE, NUM_LABELS],
                                      initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_colletion('losses', regularizer(fc2_weights))
        fc2_biases = tf.get_variable("biases", [NUM_LABELS],
                                     initializer = tf.truncated_normal_initializer(stddev = 0.1))
        logit = tf.matmul(fc1, fc2_weights) + fc2_biases

    return logit
'''