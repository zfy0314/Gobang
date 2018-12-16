#------------------------------
# helper lib
# written by zfy 12-14-2018
#------------------------------

from __future__ import print_function
import matplotlib.pyplot as plt
import numpy as np
from os import listdir
from os import system
from random import randint
from settings import *
from time import time

def zfy_autowrite(sequence, mode):
    if 'interaction' == mode:
        target = PATH_TO_DATASET + FILE_INTERATION_DATASET
    if 'auto' == mode:
        target = PATH_TO_DATASET + FILE_NN_DATASET
    for i in range(8): zfy_datasetwrite(target, zfy_extent(sequence, i))
    return None

def zfy_board2sequence(board):
    sequence = []
    total_step = max([max(x) for x in board])
    for i in range(total_step):
        sequence.append(zfy_findboard(board, i + 1))
    return sequence

def zfy_datasetwrite(FILE, sequence):
    if False == sequence: return None
    winner = int(len(sequence) & 1)
    for i in range(len(sequence)):
        if (int(i & 1) == winner): continue
        for j in range(i):
            with open(FILE, 'a+') as fout: fout.write(str(zfy_xy2linear(sequence[j])) + ' ')
        with open(FILE, 'a+') as fout: fout.write(';' + str(zfy_xy2linear(sequence[i])) + '\n')
    return None

def zfy_draw(path, accfile):
    with open(path + accfile, 'r') as fin: accuracy_raw = fin.read().split('\n')
    accuracy = [[eval(x.split(': ')[0]), eval(x.split(': ')[1])] for x in accuracy_raw if not '' == x]
    x = np.array([i[0] for i in accuracy])
    y = np.array([j[1] for j in accuracy])
    plt.plot(x, y)
    plt.xlabel('steps')
    plt.ylabel('accuracy')
    plt.savefig(path + 'results.jpg')
    return None

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

def zfy_extent(sequence, status):
    if 0 == status: return sequence
    if 1 == status: return [[BOARD_SIZE - 1 - x[0], x[1]] for x in sequence]
    if 2 == status: return [[x[0], BOARD_SIZE - 1 - x[1]] for x in sequence]
    if 3 == status: return [[BOARD_SIZE - 1 - x[0], BOARD_SIZE - 1 - x[1]] for x in sequence]
    if 4 == status: return [[x[1], x[0]] for x in sequence]
    if 5 == status: return [[x[1], BOARD_SIZE - 1 - x[0]] for x in sequence]
    if 6 == status: return [[BOARD_SIZE - 1 - x[1], x[0]] for x in sequence]
    if 7 == status: return [[BOARD_SIZE - 1 - x[1], BOARD_SIZE - 1 - x[0]] for x in sequence]

def zfy_findboard(board, step):
    result = [0, 0]
    for i in range(BOARD_SIZE):
        if step in board[i]:
            result[0] = i
            result[1] = board[i].index(step)
    if ([0, 0] == result) and (not board[0][0] == step): return -1
    return result

def zfy_isboard(board):
    for i in range(len(board)):
        if not len(board[i]) == len(board[0]):
            print('corrupt!, error code 0: not a board! wrong row {}'.format(i + 1))
            return False
    return True

def zfy_issequence(board):
    board_ = zfy_expand(board)[0]
    total_step = max([max(x) for x in board_])
    for i in range(total_step):
        if -1 == zfy_findboard(board_, i + 1):
            print('corrupt!, error code 1: missing number {}'.format(i + 1))
            return False
    return True

def zfy_linear2xy(index):
    return [index // BOARD_SIZE, index % BOARD_SIZE]

def zfy_print(board):
    for x in board:
        print('[', end='')
        for y in x:
            if y > 9: print(' {}'.format(y), end=' ')
            else: print(' 0{}'.format(y), end=' ') 
        print(']\n')
    print('\n')
    return None

def zfy_random(array):
    result = []
    origin = array[:]
    for i in range(len(origin) - 1, -1, -1):
        r = randint(0, i)
        result.append(origin[r])
        del origin[r]
    return result

def zfy_readtxt(FILE):
    with open(FILE, 'r') as fin: raw = fin.read()
    data = [x.replace('\r', '') for x in raw.split('\n') if not '' == x]
    board_in = [[int(x) for x in data[i].split(' ') if (not ' ' == x) and (not '' == x)] 
                for i in range(len(data))]
    return board_in

def zfy_sequence2board(sequence):
    board = [[0 for j in range(BOARD_SIZE)] for i in range(BOARD_SIZE)]
    for i in range(len(sequence)): board[sequence[i][0]][sequence[i][1]] = i + 1
    return 
    
def zfy_set(name):
    if 'train' == name:
        return None

def zfy_timer(mode):
    if 'reset' == mode: return time()
    else: return time() - mode

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

def zfy_xy2linear(position):
    return position[0] * BOARD_SIZE + position[1]
