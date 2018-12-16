#------------------------------
# BP version
# written by zfy 12-15-2018
#------------------------------

from helpers import *
import tensorflow as tf

HLAYERS = [512, 512, 512, 512, 512, 512]
BATCH_SIZE_MIN = 50
BATCH_RATIO = 0.002
TRAINING_STEPS = 20000
TRAINSET_RATIO = 0.8
CHECKPOINT_INTERVAL = 100

LEARNING_RATE_BASE = 1.8
LEARNING_RATE_DECAY =  0.993
REGULARIZATION_RATE = 0.0001
MOVING_AVERAGE_DECAY = 0.99
