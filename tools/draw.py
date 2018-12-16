from os import listdir
import numpy as np
import matplotlib.pyplot as plt
from time import time
from os import system

def acc_draw(num):
    name = 'figs-{}'.format(int(time()))
    dirs = [[x for x in listdir('.') if 'test-{}'.format(i) == x[0:6]] for i in num]
    print(dirs)
    for x in dirs: x.sort()
    f = [open('{name}/{name}.acc'.format(name=dirs[i][-1]), 'r') for i in range(len(dirs)) if not [] == dirs[i]]
    raw = [f[i].read().split('\n')[:-1] for i in range(len(dirs))]
    print(len(raw))
    system('mkdir {}'.format(name))
    for i in range(len(raw)):
        x = np.array(range(len(raw[i])))
        y = np.array([eval(k) for k in raw[i]])
        plt.figure(i)
        plt.plot(x, y)
        plt.xlabel('steps of training')
        plt.ylabel('accuracy')
        
        plt.savefig('{name}/BPNN-{num}.jpg'.format(name=name, num=i))

acc_draw([0, 1, 2, 3])
