from helpers.BP import play
from helpers.helpers import zfy_display
from helpers.settings import BOARD_SIZE

board = [0 for i in range(BOARD_SIZE ** 2)]
while True:
    #print(play(board)[0])
    #print(type(play(board)[0]))
    board[play(board)[0]] = 1
    board[play(board)[0]] = 2
    #print(board)
    #print(type(board))
    zfy_display(board)
    print('\n\n\n')
    