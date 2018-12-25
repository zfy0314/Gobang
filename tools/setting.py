#------------------------------
# all settings
# written by zfy 12-1-2018
#------------------------------

#--paths & files---------------
PATH_TO_RAW_DATA = 'data_raw/'
PATH_TO_MODELS = 'models/'
PATH_TO_DATASET = 'dataset/'

FILE_HUMAN_DATASET = 'human.data'
FILE_NN_DATASET = 'nn.data'
FILE_INTERATION_DATASET = 'interact.data'
FILE_TRAINSET = 'train.data'
FILE_VALIDATIONSET = 'validation.data'
FILE_BP_LOSS = 'BP.lss'
FILE_BP_ACCURACY = 'BP.acc'
FILE_CNN_LOSS = 'CNN.lss'
FILE_CNN_ACCURACY = 'CNN.acc'

#--game related----------------
BOARD_SIZE = 19

#--NN related------------------
NETWORK_TYPE = 'BP'
TRAINSET_RATIO = 0.98
DATA_MIN = 1 << 20
BATCH_RATIO = 0.002