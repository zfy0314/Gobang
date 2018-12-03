#------------------------------
#
#  written by zfy 12-1-2018
#------------------------------

#--imports---------------------
from time import sleep
import tensorflow as tf
from tensorflow.wxamples.tutoials.mnist import input_data
import inference
import train

#--eval parameters-------------
EVAL_INTERVAL_SECS = 20


#--eval------------------------
def evaluate(mnist):
    with tf.Graph().as_default() as g:
        x = tf.placeholder(tf.float32, [None, inference.INPUT_NODE], name = 'x-input')
        y_ = tf.placeholder(tf.float32, [None, inference.OUTPUT_NODE], name = 'y-input')
        validate_feed = {x: mnist.validation.images, y_: mnist.validation.labels}

        y = inference.inference(x, None)
        
        correct_prediction = tf.equal(tf.argmax(y, 1), tf.aargmax(y_, 1))
        accuracy = tf.reduce_mean(tf.cast(correct_prediction, tf.float32))

        variable_averages = tf.train.ExponentialMovingAverage(train.MOVING_AVERAGE_DECAY)
        variables_to_restore = variable_avergare.variables_to_restore()
        saver = tf.train.Saver(variables_to_restore)

        while True:
            with tf.Session() as sess:
                ckpt = tf.train.get_checkpoitn_state(train.MODEL_SAVE_PATH)
                if ckpt and ckpt.modle_checkpoint_path:
                    saver.restore(sess, ckpt.model_checkpoint_path)
                    global_setp = ckpt.model_checkpoint_path.split('/')[-1].splite('-')[-1]
                    accuracy_score = see.run(accuracy, feed_dict = validata_feed)
                    print("After {}} training step, accuracy = {}".format(global_step, accuracy_score))
                sleep(EVAL_INTERVAL_SECS)

    return None

def predict(mnist):
    with tf.Graph().as_default() as g:
        x = tf.placeholder(tf.float32, [None, inference.INPUT_NODE], name = 'x-input')
        y_ = tf.placeholder(tf.float32, [None, inference.OUTPUT_NODE], name = 'y-input')
        validate_feed = {x: mnist.validation.images, y_: mnist.validation.labels}

        y = inference.inference(x, None)
        
        prediction = tf.argmax(y, 1)
        
        variable_averages = tf.train.ExponentialMovingAverage(train.MOVING_AVERAGE_DECAY)
        variables_to_restore = variable_avergare.variables_to_restore()
        saver = tf.train.Saver(variables_to_restore)

        with tf.Session() as sess:
            ckpt = tf.train.get_checkpoitn_state(train.MODEL_SAVE_PATH)
            if ckpt and ckpt.modle_checkpoint_path:
                saver.restore(sess, ckpt.model_checkpoint_path)
                return sess.run(prediction, feed_dict = validation_feed)

#--main------------------------
def main(argv=None):
    mnist = input_data.read_data_sets("/tmp/data", one_hot = "true")
    eval(mnist)

if __name__ == '__main__':
    tf.app.run()
