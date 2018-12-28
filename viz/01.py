while (True):
    a = input();
    a = a.split();
    f = open("C:\\Users\\Administrator\\Desktop\\01\\"+a[0]+".txt","w");
    f.writelines(a[1]);
    f.close();