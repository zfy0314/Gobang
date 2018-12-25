#------------------------------
# play gobang
# written by zfy 12-21-2018
#------------------------------

from helpers import CNN
from helpers import BP
from helpers.helpers import zfy_display
from helpers.settings import *

def play_BP(board):
    result = BP.play(board)
    board_new = board
    board_new[result] = int(board_new.count(1) > board_new.count(2)) + 1
    return board_new

def play_CNN(board):
    result = CNN.play(board)
    board_new = board
    board_new[result] = int(board_new.count(1) > board_new.count(2)) + 1
    return board_new
    
def main():
    board = [0 for i in range(BOARD_SIZE ** 2)]
    while True:
        board = play_BP(board)
        zfy_display(board)
        next_step = 
        

if __name__ == '__main__':
