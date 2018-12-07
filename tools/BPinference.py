#------------------------------
#
# written by zfy 12-04-2018
#------------------------------

#--import----------------------
import tensorflow as tf

#--inference-------------------
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
