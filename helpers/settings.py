#------------------------------
# all settings
# written by zfy 12-15-2018
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

#--game related----------------
BOARD_SIZE = 19

#--NN related------------------
TRAINSET_RATIO = 0.9
DATA_MIN = 1 << 20
BATCH_RATIO = 0.002