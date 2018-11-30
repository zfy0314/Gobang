from os import listdir
from time import time

FILE = 'test.txt'

def num_threshold(num, thres):
    if num > thres: return 0
    else: return num

def board_min(BOARD, MAX):
    return [[num_threshold(BOARD[i][j], MAX) for j in range(len(BOARD[i]))] for i in range(len(BOARD))]

def txt_read(FILE):
    with open(FILE, 'r') as fin:
        raw = fin.read()
    data = [x for x in raw.split('\n') if not '' == x]
    temp = data[0].split(' ')
    mode = int(temp[0])
    size = [int(x) for x in temp[1:]]

    board_u = [[int(x) for x in data[i] if not ' ' == x] for i in range(1, len(data))]
    step_total = max(max(board_u))
    result = [board_min(board_u, 2 * i + 1) for i in range(step_total // 2 + 1)]

    '''
    print(board_u)
    print(mode)
    print(temp)
    print(size)
    '''
    
