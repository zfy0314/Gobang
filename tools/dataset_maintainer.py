#------------------------------
# maintain trainset and validation set
# written by zfy 12-02-2018
#------------------------------

#--imports---------------------
from setting import *
from random import randint
from os import listdir
from raw2dataset import zfy_timer

#--helper functions------------
def zfy_txt2data(FILE):
    with open(FILE, 'r') as fin: raw = fin.read().split('\n')
    data = []
    for x in raw:
        if '' == x: continue
        result = [[0 for i in range(BOARD_SIZE ** 2)], [0 for j in range(BOARD_SIZE ** 2)]]
        if not ' ;' in x:
            result[1][eval(x[1:])] = 1
            data.append(result)
            continue
        temp = x.split(' ;')
        result[1][eval(temp[-1].replace(';', ''))] = 1
        sequence = [eval(y) for y in temp[0].split(' ') if not ' ' == y]
        winner = int(len(sequence) & 1)
        for i in range(len(sequence)):
            result[0][sequence[i]] = 1 + int((i & 1) == winner)
        result[0] = tuple(result[0])
        result[1] = tuple(result[1])
        data.append(result)
    return data


def zfy_random(array):
    result = []
    origin = array[:]
    for i in range(len(origin) - 1, -1, -1):
        r = randint(0, i)
        result.append(origin[r])
        del origin[r]
    return result

#--main------------------------
def get_set(set_name):
    if None == set_name:
        raw = []
        if FILE_NN_DATASET in listdir(PATH_TO_DATASET):
            with open(PATH_TO_DATASET + FILE_NN_DATASET, 'r') as fin: raw = fin.read().split('\n')
        if FILE_INTERATION_DATASET in listdir(PATH_TO_DATASET):
            with open(PATH_TO_DATASET + FILE_INTERATION_DATASET, 'r') as fin: raw = raw + fin.read().split('\n')
        if len(raw) < DATA_MIN:
            with open(PATH_TO_DATASET + FILE_HUMAN_DATASET, 'r') as fin: raw = raw + fin.read().split('\n')
        raw = zfy_random(raw)
        #with open(PATH_TO_DATASET + FILE_TRAINSET, 'w') as fout:
        #    for x in raw[:int(len(raw) * TRAINSET_RATIO)]:  fout.write(x + '\n')
        for i in range(int(1//BATCH_RATIO)):
            with open(PATH_TO_DATASET + FILE_TRAINSET + '-{}'.format(i), 'w') as fout:
                for x in raw[int(i * len(raw) * BATCH_RATIO):int((i + 1) * len(raw) * BATCH_RATIO)]: fout.write(x + '\n')
        with open(PATH_TO_DATASET + FILE_VALIDATIONSET, 'w') as fout:
            for x in raw[int(len(raw) * TRAINSET_RATIO):]: fout.write(x + '\n')
        return None
    if 'train' == set_name[:5]: return zfy_txt2data(PATH_TO_DATASET + FILE_TRAINSET + '-{}'.format(set_name[5:]))
    if 'validate' == set_name: return zfy_txt2data(PATH_TO_DATASET + FILE_VALIDATIONSET)
    return None

def test():
    print(get_set('train')[-1])

def main(argv = None):
    t = zfy_timer('reset')
    get_set(None)
    #test()
    print('done after {} seconds'.format(zfy_timer(t)))

if __name__ == '__main__':
    main()
