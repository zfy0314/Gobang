#------------------------------
# new method convertion
# written by zfy 12-2-2018
#------------------------------

#--imports---------------------
from os import listdir
from time import time
from setting import *

#--helper functions------------
def zfy_extent(sequence, status):
    if 0 == status: return sequence
    if 1 == status: return [[BOARD_SIZE + 1 - x[0], x[1]] for x in sequence]
    if 2 == status: return [[x[0], BOARD_SIZE + 1 - x[1]] for x in sequence]
    if 3 == status: return [[BOARD_SIZE + 1 - x[0], BOARD_SIZE + 1 - x[1]] for x in sequence]
    if 4 == status: return [[x[1], x[0]] for x in sequence]
    if 5 == status: return [[x[1], BOARD_SIZE + 1 - x[0]] for x in sequence]
    if 6 == status: return [[BOARD_SIZE + 1 - x[1], x[0]] for x in sequence]
    if 7 == status: return [[BOARD_SIZE + 1 - x[1], BOARD_SIZE + 1 - x[0]] for x in sequence]

def zfy_expand(board_mini):
    boards = []
    size = [len(board_mini), len(board_mini[0])]
    for i in range(1, BOARD_SIZE - size[0]):
        for j in range(1, BOARD_SIZE - size[1]):
            temp = [[0 for k in range(BOARD_SIZE)] for l in range(BOARD_SIZE)]
            for l in range(size[0]):
                for k in range(size[1]):
                    temp[i+l][j+k] = board_mini[l][k]
            boards.append(temp)
    return boards

def zfy_sequence2board(sequence):
    board = [[0 for j in range(BOARD_SIZE)] for i in range(BOARD_SIZE)]
    for i in range(len(sequence)): board[sequence[i][0]][sequence[i][1]] = i + 1
    return board

def zfy_board2sequence(board):
    sequence = []
    total_step = max([max(x) for x in board])
    for i in range(total_step):
        sequence.append(zfy_findboard(board, i + 1))
    return sequence

def zfy_findboard(board, step):
    result = [0, 0]
    for i in range(BOARD_SIZE):
        if step in board[i]:
            result[0] = i
            result[1] = board[i].index(step)
    return result

def zfy_readtxt(FILE):
    with open(FILE, 'r') as fin: raw = fin.read()
    data = [x.replace('\r', '') for x in raw.split('\n') if not '' == x]
    board_in = [[int(x) for x in data[i].split(' ') if not ' ' == x] 
                for i in range(len(data))]
    return board_in

def zfy_xy2linear(position):
    return position[0] * BOARD_SIZE + position[1]

def zfy_datasetwrite(FILE, sequence):
    winner = int(len(sequence) & 1)
    for i in range(len(sequence)):
        if (int(i & 1) == winner): continue
        for j in range(i):
            with open(FILE, 'a+') as fout: fout.write(str(zfy_xy2linear(sequence[j])) + ' ')
        with open(FILE, 'a+') as fout: fout.write(';' + str(zfy_xy2linear(sequence[i])) + '\n')

def zfy_timer(mode):
    if 'reset' == mode: return time()
    else: return time() - mode

def zfy_print(board):
    for x in board: print(x)
    print('\n')
    return None

#--main------------------------
def dataset_init():
    dirs = listdir(PATH_TO_RAW_DATA)
    t = int(time())
    for x in dirs:
        timer = zfy_timer('reset')
        print('start processing {}.'.format(x))
        for sequence in [zfy_board2sequence(board) for board in zfy_expand(zfy_readtxt(PATH_TO_RAW_DATA + x))]:
            for i in range(8): zfy_datasetwrite(PATH_TO_DATASET + 'human-' + str(t)[3:] + '.txt', zfy_extent(sequence, i))
        print('finish converting {} using {} seconds'.format(x, zfy_timer(timer)))

def test():
    dirs = listdir(PATH_TO_RAW_DATA)
    timer = zfy_timer('reset')
    x = dirs[0]
    print('start processing {}.'.format(x))
    point = zfy_expand(zfy_readtxt(PATH_TO_RAW_DATA + x))[0]
    zfy_print(point)
    print(zfy_board2sequence(point))
    zfy_print(zfy_sequence2board(zfy_board2sequence(point)))
    

def main(argv = None):
    dataset_init()
    #test()

if __name__ == '__main__':
    main()
