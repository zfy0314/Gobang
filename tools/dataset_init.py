#------------------------------
# convert chess board to data slice
# written by zfy 11-30-2018
#------------------------------

#--imports---------------------
from os import listdir
from time import time
from setting import *

DATASET_FILE = PATH_TO_HUMAN_DATASET

#--helper functions------------
def num_threshold(num, thres):
    if num > thres: return 0
    else: return num

def board_min(board, mmax):
    return [[num_threshold(board[i][j], mmax)
            for j in range(len(board[i]))] 
            for i in range(len(board))]

def zfy_rotate(matrix, num):
    result = matrix
    for i in range(num):
        result = map(list, zip(*matrix[::-1]))
    return result

def data_write(FILE, board):
    [x, y, mmax] = zfy_max(board)
    fout = open(FILE, 'a+')
    for i in range(BOARD_SIZE):
        for j in range(BOARD_SIZE):
            if 0 == board[i][j]: fout.write('0 ')
            elif mmax == board[i][j]: fout.write('0 ')
            else: fout.write(str(2 - int((mmax & 1) == (board[i][j] % 2))) + ' ')
    for i in range(BOARD_SIZE):
        for j in range(BOARD_SIZE):
            if mmax == board[i][j]: fout.write('1 ')
            else: fout.write('0 ')
    fout.write('\n')
    fout.close()
    return None

def zfy_print(matrix):
    for x in matrix: print(x)
    print('\n')
    return None

def zfy_max(array):
    x, y = -1, -1
    mmax = 0
    for i in range(len(array)):
        for j in range(len(array[i])):
            if array[i][j] > mmax: x, y, mmax = i, j, array[i][j]
    return [x, y, mmax]

def zfy_timer(mode):
    if 'reset' == mode: return time()
    else: return time() - mode

#--functions-------------------
def txt_read(FILE):
    with open(FILE, 'r') as fin:
        raw = fin.read()
    data = [x.replace('\r', '') for x in raw.split('\n') if not '' == x]
    board_u = [[int(x) for x in data[i].split(' ') if not ' ' == x] 
               for i in range(len(data))]
    step_total = zfy_max(board_u)[2]
    result = [board_min(board_u, 2 * i + 1) 
              for i in range(step_total // 2 + 2 - (step_total % 2))]
    return result

def dataset_write(FILE, BOARDS):
    size = [len(BOARDS[0]), len(BOARDS[0][0])]
    for brd in BOARDS:
        for i in range(1, BOARD_SIZE - size[0]):
            for j in range(1, BOARD_SIZE - size[1]):
                temp = [[0 for k in range(BOARD_SIZE)] for l in range(BOARD_SIZE)]
                for l in range(size[0]):
                    for k in range(size[1]):
                        temp[i+l][j+k] = brd[l][k]
                for l in [0, 1, 2, 3]:
                    data_write(FILE, zfy_rotate(temp, l))
    #print('{}: {} finished.'.format(int(time()), FILE))
    return None
    
#--main------------------------
def slice(PATH):
    dirs = listdir(PATH)
    for x in dirs: 
        t = zfy_timer('reset')
        print('starting {} ..'.format(x))
        dataset_write(DATASET_FILE, txt_read(PATH + x))
        print('finished preparing {} used {} sec.'.format(x, zfy_timer(t)))
    print('done preparing human dataset')

def main(argv=None):
    slice(PATH_TO_RAW_DATA)

if __name__ == '__main__':
    main()
