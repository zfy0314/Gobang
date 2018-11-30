#------------------------------
#convert chess board to data slice
#written by zfy 11-30-2018
#------------------------------

#--imports---------------------
from os import listdir
from time import time

#--global variables------------
PATH_TO_RAW_DATA = 'data_raw/'
DATASET_FILE = 'dataset/human_data.txt'
BOARD_SIZE = 19

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
    mmax = max(max(board))
    x = max(board).index(mmax)
    y = board[x].index(mmax)
    fout = open(FILE, 'a+')
    for i in range(BOARD_SIZE):
        for j in range(BOARD_SIZE):
            if 0 == board[i][j]: fout.write('0 ')
            elif mmax == board[i][j]: fout.write('0 ')
            else: board[i][j] = fout.write(str(2 - int((mmax % 2) == (board[i][j] % 2))) + ' ')
    for i in range(BOARD_SIZE):
        for j in range(BOARD_SIZE):
            if mmax == board[i][j]: fout.write('1 ')
            else: fout.write('0 ')
    return None

#--functions-------------------
def txt_read(FILE):
    with open(FILE, 'r') as fin:
        raw = fin.read()
    data = [x.replace('\r', '') for x in raw.split('\n') if not '' == x]

    board_u = [[int(x) for x in data[i] if not ' ' == x] 
               for i in range(len(data))]
    step_total = max(max(board_u))
    result = [board_min(board_u, 2 * i + 1) 
              for i in range(step_total // 2 + 2 - (step_total % 2))]
    '''
    print(board_u)
    print(mode)
    print(result)
    '''
    return result

def dataset_write(FILE, BOARDS):
    size = [len(BOARDS[0]), len(BOARDS[0][0])]
    print(size)
    for brd in BOARDS:
        for i in range(1, BOARD_SIZE - size[0] - 1):
            for j in range(1, BOARD_SIZE - size[1] - 1):
                temp = [[0] * BOARD_SIZE] * BOARD_SIZE
                for l in range(size[0]):
                    for k in range(size[1]):
                        temp[i+l][j+k] = brd[l][k]
                for l in [0, 1, 2, 3]:
                    #data_write(FILE, zfy_rotate(temp, l))
                     print(temp)
                     print(brd)
                
    
#--main------------------------
def slice(PATH):
    dirs = listdir(PATH)
    for x in dirs: dataset_write(DATASET_FILE, txt_read(PATH + x))
    print('done preparing human dataset')

def main(argv=None):
    slice(PATH_TO_RAW_DATA)

if __name__ == '__main__':
    main()
