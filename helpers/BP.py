#------------------------------
# BP
# written by zfy 12-21-2018
#------------------------------

import tensorflow as tf
from helpers import *
from settings import *

INPUT_NODE = BOARD_SIZE ** 2
OUTPUT_NODE = INPUT_NODE
NUM_LABELS = OUTPUT_NODE

HLAYERS = [512, 512, 512, 512, 512, 512]

BATCH_RATIO = 0.002
TRAINING_STEPS = 10000
CHECKPOINT_INTERVAL = 100
SAVER_INTERVAL = 20

LEARNING_RATE_BASE = 0.2
LEARNING_RATE_DECAY = 0.9993
REGULARIZATION_RATE = 0.0001
MOVING_AVERAGE_DECAY = 0.99

def inference(input_tensor, regularizer):
    '''
    LAYERS = [INPUT_NODE] + HLAYERS + [OUTPUT_NODE]
    output = input_tensor
    for i in range(len(LAYERS) - 1):
        with tf.variable_scope('fc{}'.format(i)):
            fc_weights = tf.get_variable('weight{}'.format(i), [LAYERS[i], LAYERS[i + 1]],
                                      initializer = tf.truncated_normal_initializer(stddev = 0.1))
            if not None == regularizer:
                tf.add_to_collection('losses', regularizer(fc_weights))
            fc_biases = tf.get_variable('bias{}'.format(i), [LAYERS[i + 1]], initializer = tf.constant_initializer(1.0))
            output = tf.nn.relu(tf.matmul(output, fc_weights) + fc_biases)
    
    '''
    with tf.variable_scope('fc1'):
        fc_weights = tf.get_variable('weight1', [INPUT_NODE, HLAYERS[0]],
                                   initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc_weights))
        fc_biases = tf.get_variable('bias1', [HLAYERS[0]], initializer = tf.constant_initializer(0.1))
        output_fc1 = tf.nn.relu(tf.matmul(input_tensor, fc_weights) + fc_biases)
    
    with tf.variable_scope('fc2'):
        fc_weights = tf.get_variable('weight2', [HLAYERS[0], HLAYERS[1]],
                                   initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc_weights))
        fc_biases = tf.get_variable('bias2', [HLAYERS[1]], initializer = tf.constant_initializer(0.1))
        output_fc2 = tf.nn.relu(tf.matmul(output_fc1, fc_weights) + fc_biases)
    
    with tf.variable_scope('fc3'):
        fc_weights = tf.get_variable('weight3', [HLAYERS[1], HLAYERS[2]],
                                   initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc_weights))
        fc_biases = tf.get_variable('bias3', [HLAYERS[2]], initializer = tf.constant_initializer(0.1))
        output_fc3 = tf.nn.relu(tf.matmul(output_fc2, fc_weights) + fc_biases)

    with tf.variable_scope('fc4'):
        fc_weights = tf.get_variable('weight4', [HLAYERS[2], HLAYERS[3]],
                                   initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc_weights))
        fc_biases = tf.get_variable('bias4', [HLAYERS[3]], initializer = tf.constant_initializer(0.1))
        output_fc4 = tf.nn.relu(tf.matmul(output_fc3, fc_weights) + fc_biases)

    with tf.variable_scope('fc5'):
        fc_weights = tf.get_variable('weight5', [HLAYERS[3], HLAYERS[4]],
                                   initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc_weights))
        fc_biases = tf.get_variable('bias5', [HLAYERS[4]], initializer = tf.constant_initializer(0.1))
        output_fc5 = tf.nn.relu(tf.matmul(output_fc4, fc_weights) + fc_biases)

    with tf.variable_scope('fc6'):
        fc_weights = tf.get_variable('weight6', [HLAYERS[4], HLAYERS[5]],
                                   initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc_weights))
        fc_biases = tf.get_variable('bias6', [HLAYERS[5]], initializer = tf.constant_initializer(0.1))
        output_fc6 = tf.nn.relu(tf.matmul(output_fc5, fc_weights) + fc_biases)

    with tf.variable_scope('fc7'):
        fc_weights = tf.get_variable('weight7', [HLAYERS[5], OUTPUT_NODE],
                                   initializer = tf.truncated_normal_initializer(stddev = 0.1))
        if not None == regularizer:
            tf.add_to_collection('losses', regularizer(fc_weights))
        fc_biases = tf.get_variable('bias7', [OUTPUT_NODE], initializer = tf.constant_initializer(0.1))
        output = tf.nn.relu(tf.matmul(output_fc6, fc_weights) + fc_biases)
    

    return output


def train(name):
    x = tf.placeholder(tf.float32, [None, INPUT_NODE], name = 'x-input')
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
        with open(PATH_TO_MODELS_BP + FILE_BP_SPEC, 'a+') as fout:
            fout.write('\n')
        
        for i in range(TRAINING_STEPS + 1):
            
            dataset = zfy_getset('train{}'.format(i%int(1//BATCH_RATIO)))
            train_feed = {x: [data[0] for data in dataset], y_: [data[1] for data in dataset]}
            _, loss_value, step = sess.run([train_op, loss, global_step], feed_dict = train_feed)
            print('step {}: loss = {}, time used {} seconds'.format(i, loss_value, zfy_timer(timer)))
            timer = zfy_timer('reset')
            with open(PATH_TO_MODELS_BP + 'model.lss', 'a+') as fout:
                fout.write('{}: {}\n'.format(i, loss_value))
            #if 0 == i % CHECKPOINT_INTERVAL:
                #print(evaluate(True))
            
            if 0 == i % SAVER_INTERVAL:
                saver.save(sess, PATH_TO_MODELS_BP + name + '.ckpt', global_step = step)
                #acc = evaluate()
                #print('step {}: accuracy = {}'.format(i, acc))
                #with open(PATH_TO_MODELS_BP + 'model.acc', 'a+') as fout:
                #    fout.write('{}: {}\n'.format(i, acc))
            
                
    return None
    
def evaluate():
    with tf.Graph().as_default() as g:
        x = tf.placeholder(tf.float32, [None, INPUT_NODE], name = 'x-input')
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
            test_feed = {x: [data[0] for data in testset], y_: [data[1] for data in testset]}
            ckpt = tf.train.get_checkpoint_state(PATH_TO_MODELS_BP)
            saver.restore(sess, ckpt.model_checkpoint_path)
            global_step = ckpt.model_checkpoint_path.split('-')[-1]
            score = sess.run(accuracy, feed_dict = test_feed)
    return score

def play(board):
    with tf.Graph().as_default() as g:
        x = tf.placeholder(tf.float32, [None, INPUT_NODE], name = 'x-input')
        y = inference(x, None)
        prediction = tf.argmax(y, 1)
        variable_averages = tf.train.ExponentialMovingAverage(MOVING_AVERAGE_DECAY)
        variables_to_restore = variable_averages.variables_to_restore()
        saver = tf.train.Saver(variables_to_restore)

        with tf.Session() as sess:
            ckpt = tf.train.get_checkpoint_state(PATH_TO_MODELS_BP)
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