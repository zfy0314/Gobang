#------------------------------
# recorder written by zfy
# 11-15-2018
#------------------------------
# black(self) -> 1
# white(oppo) -> -1
#------------------------------

#--imports---------------------
from os import listdir
from time import time

#--global variables------------
N = 15
M = 5
OUT_FILE = '{}.txt'.format(int(time())

BLK0 = [[1, 1, 1, 1, 1], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0]]
BLK1 = [[0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [1, 1, 1, 1, 1]]
BLK2 = [[1, 0, 0, 0, 0], [0, 1, 0, 0, 0], [0, 0, 1, 0, 0], [0, 0, 0, 1, 0], [0, 0, 0, 0, 1]]
BLK3 = [[0, 0, 0, 0, 1], [0, 0, 0, 1, 0], [0, 0, 1, 0, 0], [0, 1, 0, 0, 0], [1, 0, 0, 0, 0]]
BLK4 = [[1, 0, 0, 0, 0], [1, 0, 0, 0, 0], [1, 0, 0, 0, 0], [1, 0, 0, 0, 0], [1, 0, 0, 0, 0]]
BLK5 = [[0, 0, 0, 0, 1], [0, 0, 0, 0, 1], [0, 0, 0, 0, 1], [0, 0, 0, 0, 1], [0, 0, 0, 0, 1]]

WHT0 = [[-1, -1, -1, -1, -1], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0]]
WHT1 = [[0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [0, 0, 0, 0, 0], [-1, -1, -1, -1, -1]]
WHT2 = [[-1, 0, 0, 0, 0], [0, -1, 0, 0, 0], [0, 0, -1, 0, 0], [0, 0, 0, -1, 0], [0, 0, 0, 0, -1]]
WHT3 = [[0, 0, 0, 0, -1], [0, 0, 0, -1, 0], [0, 0, -1, 0, 0], [0, -1, 0, 0, 0], [-1, 0, 0, 0, 0]]
WHT4 = [[-1, 0, 0, 0, 0], [-1, 0, 0, 0, 0], [-1, 0, 0, 0, 0], [-1, 0, 0, 0, 0], [-1, 0, 0, 0, 0]]
WHT5 = [[0, 0, 0, 0, -1], [0, 0, 0, 0, -1], [0, 0, 0, 0, -1], [0, 0, 0, 0, -1], [0, 0, 0, 0, -1]]

#--helper functions------------
def hlp_mul(mat1, mat2):
    cnt = 0
    for i in range(M):
        for j in range(M):
             cnt = cnt + mat1[i][j] * mat2[i][j]
    if M == size:
        return 1
    else
        return 0


#--board related functions-----
def brd_init():
    return [[0 for i in range(N)] for j in range(N)]

def brd_prt(brd):
    for i in range(N):
        print(brd[i])
    return None

def brd_chk(brd):
    for i in range(N - M // 2):
        for j in range(N - M // 2):
            temp = [[brd[k][l] for k in range(i, i +  5)] for l in range(j, j + 5)]
            if hlp_mul(temp, BLK0): return 1
            if hlp_mul(temp, BLK1): return 1
            if hlp_mul(temp, BLK2): return 1
            if hlp_mul(temp, BLK3): return 1
            if hlp_mul(temp, BLK4): return 1
            if hlp_mul(temp, BLK5): return 1
            if hlp_mul(temp, WHT0): return -1
            if hlp_mul(temp, WHT1): return -1
            if hlp_mul(temp, WHT2): return -1
            if hlp_mul(temp, WHT3): return -1
            if hlp_mul(temp, WHT4): return -1
            if hlp_mul(temp, WHT5): return -1
    return 0
            
def brd_add_blk(brd, lst):
    pos = input('tpye in the position of black chess: ')
    x, y = pos[0], pos[1]
    brd[x][y] = 1
    lst.append(pos)
    brd_prt(brd)
    return brd, lst

def brd_add_wht(brd, lst):
    pos = input('type in the position of white chess: ')
    x. y = pos[0], pos[1]
    brd[x][y] = -1
    lst.append(pos)
    brd_prt(brd)
    return brd, lst

def brd_rcd(brd):
    

#--main------------------------
lst = []
brd0 = brd_init()
while (not 0 == brd_chk(brd0)):
    brd_add_blk(brd0, lst)
    brd_add_wht(brd0, lst)
brd_rcd(brd0)
