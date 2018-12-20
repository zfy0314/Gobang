#include<iostream>
#include<string>
#include<ctime>
#include<queue>
#include<stack>
using namespace std;
char qp[19][19];//棋盘，0无1电脑2玩家
//char qz[2][180][8];//对方旗子连线的方向 
//char qzx[2][180],qzy[2][180];//玩家旗子坐标 
//char qz1[180][8],qzx1[180],qzy1[180]; 
//queue<char> q2,q3,q4;//旗子
char x1,y1,z1;
char x2,y2,xx,yy,ii,bl;
char i,j,k,m,n,k1,h[9],hh[6];
char p,x3,y3;
int mm,nn,mn,nm;
//const char h[9],h1[9],h21[9],h22[9],h31[9],h4[9],h5[9];
stack<char> s3,s4,s31,s41,s32,fz1,fz3;
queue<char> q,q1,fz2,fz4,fz5,fz6,f7,f8,f9;
//s3:三联无堵，两坐标，四数，前两为威胁不大 
//s4:四联单堵，两坐标，四数，前两个为敌棋方向
//s31:三间，三坐标，六数，第三个为棋眼
//s41:四间，三坐标 
//s32:三联单堵，两坐标，前两为敌方向 

const char h1[9]={0,2,2,2,0,0,0,0,0};
const char h21[9]={0,2,2,2,1,0,0,0,0};
const char h22[9]={1,2,2,2,0,0,0,0,0};
const char h31[9]={0,2,0,2,2,0,0,0,0};
const char h32[9]={0,2,2,0,2,0,0,0,0};
const char h41[9]={1,2,2,2,2,0,0,0,0};
const char h42[9]={0,2,2,2,2,1,0,0,0};
const char h51[9]={0,2,2,2,0,2,0,0,0};
const char h52[9]={0,2,2,0,2,2,0,0,0};
const char h53[9]={0,2,0,2,2,2,0,0,0};

char szpd(char a)//数组判断
{
  switch(a)
  {
    case 1:
         for(j=0;j<9;j++)
           if(h[j]!=h1[j])
             return 0;
         return 1;
    case 21:
         for(j=0;j<9;j++)
           if(h[j]!=h21[j])
             return 0;
         return 1;
    case 22:
         for(j=0;j<9;j++)
           if(h[j]!=h22[j])
             return 0;
         return 1;
    case 31:
         for(j=0;j<9;j++)
           if(h[j]!=h31[j])
             return 0;
         return 1;
    case 32:
         for(j=0;j<9;j++)
           if(h[j]!=h32[j])
             return 0;
         return 1;
    case 41:
         for(j=0;j<9;j++)
           if(h[j]!=h41[j])
             return 0;
         return 1;
    case 42:
         for(j=0;j<9;j++)
           if(h[j]!=h42[j])
             return 0;
         return 1;
  }
} 

char pd(char x,char y,char a)//a:第几个 b:黑白 c:方向  返回：0空 1电脑 2玩家 3不存在 
{
  //x1=qp[x][y];
  //y1=qp[x][y];
  switch(a)
  {
    case 1:
         x2=x-1;
         y2=y-1;
         break;
    case 2:
         x2=x;
         y2=y-1;
         break;
    case 3:
         x2=x+1;
         y2=y-1;
         break;
    case 4:
         x2=x-1;
         y2=y;
         break; 
    case 5:
         x2=x;
         y2=y;
         break;
    case 6:
         x2=x+1;
         y2=y;
         break; 
    case 7:
         x2=x-1;
         y2=y+1;
         break; 
    case 8:
         x2=x;
         y2=y+1;
         break;
    case 9:
         x2=x+1;
         y2=y+1;
         break;
  }
  if(x2<0||y2<0||x2>18||y2>18)
    return 3;
  /*
  mm=x2;
  nn=y2;
  mn=qp[x2][y2];
  cout<<"x2,y2:"<<mm<<" "<<nn<<'='<<mn<<endl;
  */
  return qp[x2][y2];
  
}
/*char wqpd()//0:
{
  if(h[1]==1||h[2]==1||h[1]==)
}*/
void qk()//queue清空 
{
  while(q.empty()==0)
  {
    q.pop();
  }
}
void qk1()
{
  while(q1.empty()==0)
  {
    q1.pop();
  }
}

/*char pdqx()//判断棋型,0,不构成威胁 
{
  k1=q1.size();
  if(k1<=4)
    return 0;
  if(k1==5)
  {
    for(i=0;i<5;i++)
    {
      q1.push(q1.front());
      h[i]=q1.front();
      q1.pop();
      
    }
    //h1=[0,2,2,2,0,0,0,0,0];
    if(h==h1)
      return 1;
    //h1=[0,2,2,2,1,0,0,0,0]
  }
} */
void xqpd()//判断一个棋子的连线 
{
  qk1();
  k=0;//有没有遇到敌棋 
  k1=0;//遇到几个空 
  m=0;
  //fz1,3 stack
  //fz2,4 queue
  for(i=0;i<11;i++)
  {
    m=q.front();
    if(m==3)
      m=1;
    q.pop();
    q.push(m);
  }
  for(i=0;i<5;i++)
  {
    m=q.front();
    q.pop();
    fz1.push(m);
    q.push(m);
  }
  q.push(q.front());
  q.pop();
  for(i=0;i<5;i++)
  {
    m=q.front();
    q.pop();
    fz2.push(m);
    q.push(m);
  }
  //k=0;//有没有遇到敌棋 
  k1=0;//遇到几个空 
  while(fz1.empty()==0)
  {
    m=fz1.top();
    fz1.pop();
    if(m==0)
      k1++;
    if(fz3.empty()==0&&fz3.top()==0&&m==0)
      break;
    fz3.push(m);
    if(m==1)
      break;
    if(k1==2)
      break;
  }
  k1=0;
  while(fz2.empty()==0)
  {
    m=fz2.front();
    fz2.pop();
    if(m==0)
      k1++;
    if(fz4.empty()==0&&fz4.back()==0&&m==0)
      break;
    fz4.push(m);
    if(m==1)
      break;
    if(k1==2)
      break;
  }
  while(fz3.empty()==0)
  {
    q1.push(fz3.top());
    fz3.pop();
  }
  q1.push(2);
  while(fz4.empty()==0)
  {
    q1.push(fz4.front());
    fz4.pop();
  }
  while(fz1.empty()==0)
    fz1.pop();
  while(fz2.empty()==0)
    fz2.pop();
  //n=0;
  /*for(i=0;i<9;i++)
  {
    m=q.front();
    q.pop()
    if(m==2)
      k=1;
    if(m==0)
      k1++;
    if(k==0)
      k1=0;
    if(q1.back()==0&&m==0&&i>4)
      break;
    //if(m==0)
    if((m==1||m==3)&&i<4)
      qk1();
    q1.push(m);
    if((m==1||m==3)&&i>4)
      break;
    if(k1==2)
      break;
    //if(i>4&&n==0&&m==0)
  }*/
  /*
  m=q1.size();
  nn=m;
  cout<<"size:"<<nn<<endl;
  for(i=0;i<m;i++)
  {
    n=q1.front();
    nn=n;
    cout<<nn<<' ';
    q1.pop();
    q1.push(n);
  }
  cout<<endl;
  */
}
char djg()//第几个
{
  
  for(i=0;i<9;i++)
  {
    while(fz5.empty()==0)
      fz5.pop();
    for(j=0;j<11;j++)
    {
      fz5.push(q.front());
      q.push(q.front());
      q.pop();
    }
    for(j=0;j<q1.size();j++)
    {
      fz6.push(q1.front());
      q1.push(q1.front());
      q1.pop();
    }
    k=0;
    while(k<i)
    {
      fz5.pop();
      k++;
    }
    k=0;
    while(fz6.empty()==0)
    {
      if(fz6.front()!=fz5.front())
      {
        k=1;
        break;
      }
      else
      {
        fz6.pop();
        fz5.pop();
      }
    }
    while(fz6.empty()==0)
      fz6.pop();
    while(fz5.empty()==0)
      fz5.pop();
    if(k==0)
      return i;
  }
  
} 
void lxpd(char x,char y,char a)//连线 
{
  //k=0;
  switch(a)
  {
    case 1:
         for(i=0;i<11;i++)
           q.push(qp[x+i-5][y+i-5]);
         break;
    case 2:
         for(i=0;i<11;i++)
           q.push(qp[x][y+i-5]);
         break;
    case 3:
         for(i=0;i<11;i++)
           q.push(qp[x-i+5][y+i-5]);
         break;
    case 4:
         for(i=0;i<11;i++)
           q.push(qp[x+i-5][y]);
         break;
   
  }
  
  //jianyan 
  m=q.size();
  nn=m;
  /*
  cout<<"q.size:"<<nn<<endl;
  for(i=0;i<m;i++)
  {
    n=q.front();
    nn=n;
    cout<<nn<<' ';
    q.pop();
    q.push(n);
  }
  
  cout<<endl;*/
  
  xqpd();
  
  
  k1=q1.size();
  k=djg();
  qk();
  
  for(i=0;i<9;i++)
  {
    if(i<k1)
    {
      q1.push(q1.front());
      h[i]=q1.front();
      q1.pop();
    }
    else
      h[i]=0;
      
  }
  
  /*cout<<endl<<"h:";//ffffffffffzzzzzzzzzzz
  for(i=0;i<9;i++)
  {
    nn=h[i];
    cout<<nn<<' ';
  }
  cout<<endl;*/
  
  if(k1<=4)
    return;
  if(szpd(1)==1)
  {
    switch(a)
    {
      case 1:
           s3.push(x-4+k);
           s3.push(y-4+k);
           s3.push(x-2+k);
           s3.push(y-2+k);
           break;
      case 2:
           s3.push(x);
           s3.push(y-4+k);
           s3.push(x);
           s3.push(y-2+k);
           break;
      case 3:
           s3.push(x+4-k);
           s3.push(y-4+k);
           s3.push(x+2-k);
           s3.push(y-2+k);
           break;
      case 4:
           s3.push(x-4+k);
           s3.push(y);
           s3.push(x-2+k);
           s3.push(y);
           break;
    }
    return;
  }
  if(szpd(21)==1)
  {
    switch(a)
    {
      case 1:
           s32.push(x-2+k);
           s32.push(y-2+k);
           s32.push(x-4+k);
           s32.push(y-4+k);
           break;
      case 2:
           s32.push(x);
           s32.push(y-2+k);
           s32.push(x);
           s32.push(y-4+k);
           break;
      case 3:
           s32.push(x+2-k);
           s32.push(y-2+k);
           s32.push(x+4-k);
           s32.push(y-4+k);
           break;
      case 4:
           s32.push(x-2+k);
           s32.push(y);
           s32.push(x-4+k);
           s32.push(y);
           break;
    }
    return;
  }
  if(szpd(22)==1)
  {
    switch(a)
    {
      case 1:
           s32.push(x-4+k);
           s32.push(y-4+k);
           s32.push(x-2+k);
           s32.push(y-2+k);
           break;
      case 2:
           s32.push(x);
           s32.push(y-4+k);
           s32.push(x);
           s32.push(y-2+k);
           break;
      case 3:
           s32.push(x+4-k);
           s32.push(y-4+k);
           s32.push(x+2-k);
           s32.push(y-2+k);
           break;
      case 4:
           s32.push(x-4+k);
           s32.push(y);
           s32.push(x-2+k);
           s32.push(y);
           break;
    }
    return;
  }
  if(szpd(31)==1)
  {
    switch(a)
    {
      case 1:
           s31.push(x-4+k);
           s31.push(y-4+k);
           s31.push(x-1+k);
           s31.push(y-1+k);
           s31.push(x-3+k);
           s31.push(y-3+k);
           break;
      case 2:
           s31.push(x);
           s31.push(y-4+k);
           s31.push(x);
           s31.push(y-1+k);
           s31.push(x);
           s31.push(y-3+k);
           break;
      case 3:
           s31.push(x+4-k);
           s31.push(y-4+k);
           s31.push(x+1-k);
           s31.push(y-1+k);
           s31.push(x+3-k);
           s31.push(y-3+k);
           break;
      case 4:
           s31.push(x-4+k);
           s31.push(y);
           s31.push(x-1+k);
           s31.push(y);
           s31.push(x-3+k);
           s31.push(y);
           break;
    }
    return;
  }
  if(szpd(32)==1)
  {
    switch(a)
    {
      case 1:
           s31.push(x-4+k);
           s31.push(y-4+k);
           s31.push(x-1+k);
           s31.push(y-1+k);
           s31.push(x-2+k);
           s31.push(y-2+k);
           break;
      case 2:
           s31.push(x);
           s31.push(y-4+k);
           s31.push(x);
           s31.push(y-1+k);
           s31.push(x);
           s31.push(y-2+k);
           break;
      case 3:
           s31.push(x+4-k);
           s31.push(y-4+k);
           s31.push(x+1-k);
           s31.push(y-1+k);
           s31.push(x+2-k);
           s31.push(y-2+k);
           break;
      case 4:
           s31.push(x-4+k);
           s31.push(y);
           s31.push(x-1+k);
           s31.push(y);
           s31.push(x-2+k);
           s31.push(y);
           break;
    }
    return;
  }
  if(szpd(41)==1)
  {
    switch(a)
    {
      case 1:
           s4.push(x-4+k);
           s4.push(y-4+k);
           s4.push(x-1+k);
           s4.push(y-1+k);
           break;
      case 2:
           s4.push(x);
           s4.push(y-4+k);
           s4.push(x);
           s4.push(y-1+k);
           break;
      case 3:
           s4.push(x+4-k);
           s4.push(y-4+k);
           s4.push(x+1-k);
           s4.push(y-1+k);
           break;
      case 4:
           s4.push(x-4+k);
           s4.push(y);
           s4.push(x-1+k);
           s4.push(y);
           break;
    }
    return;
  }
  if(szpd(42)==1)
  {
    switch(a)
    {
      case 1:
           s4.push(x-1+k);
           s4.push(y-1+k);
           s4.push(x-4+k);
           s4.push(y-4+k);
           break;
      case 2:
           s4.push(x);
           s4.push(y-1+k);
           s4.push(x);
           s4.push(y-4+k);
           break;
      case 3:
           s4.push(x+1-k);
           s4.push(y-1+k);
           s4.push(x+4-k);
           s4.push(y-4+k);
           break;
      case 4:
           s4.push(x-1+k);
           s4.push(y);
           s4.push(x-4+k);
           s4.push(y);
           break;
    }
    return;
  }
  m=0;
  //k1=0;
  for(i=1;i<6;i++)
  {
    if(h[i]!=0&&h[i]!=2)
      break;
    if(h[i]==0)
    {
      m=m+1;
      n=i;
    }
      
    if(m==2)
      break;
    if(i==5)
    {
      switch(a)
    {
      case 1:
           s41.push(x+k);
           s41.push(y+k);
           s41.push(x-4+k);
           s41.push(y-4+k);
           s41.push(x+n-5+k);
           s41.push(y+n-5+k);
           break;
      case 2:
           s41.push(x);
           s41.push(y+k);
           s41.push(x);
           s41.push(y-4+k);
           s41.push(x);
           s41.push(y+n-5+k);
           break;
      case 3:
           s41.push(x-k);
           s41.push(y+k);
           s41.push(x+4-k);
           s41.push(y-4+k);
           s41.push(x-n+5-k);
           s41.push(y+n-5+k);
           break;
      case 4:
           s41.push(x+k);
           s41.push(y);
           s41.push(x-4+k);
           s41.push(y);
           s41.push(x+n-5+k);
           s41.push(y);
           break;
    }
    }
    
    
  }
  
}
void sc()//输出 
{
  for(i=0;i<19;i++)
  {
    for(j=0;j<19;j++)
    {
      mm=qp[j][i];
      cout<<mm<<' ';
    }
    cout<<endl;
  }
}

void xq1(char x,char y)//纯防守下棋
{
  while(s4.empty()==0)
  {
    for(i=0;i<4;i++)
    {
      hh[3-i]=s4.top();
      s4.pop();
    }
    if(hh[0]<hh[2])
      x3=hh[2]+1;
    else if(hh[0]==hh[2])
      x3=hh[2];
    else if(hh[0]>hh[2])
      x3=hh[2]-1;
    
    if(hh[1]<hh[3])
      y3=hh[3]+1;
    else if(hh[1]==hh[3])
      y3=hh[3];
    else if(hh[1]>hh[3])
      y3=hh[3]-1;
      
    if(x3>=0&&x3<=18&&y3>=0&&y3<=18&&qp[x3][y3]==0)
      return;
    
  }
  
  while(s3.empty()==0)
  {
    for(i=0;i<4;i++)
    {
      hh[3-i]=s3.top();
      s3.pop();
    }
    srand(time(0));
    if(rand()%2==0)
    {
    if(hh[0]<hh[2])
      x3=hh[2]+1;
    else if(hh[0]==hh[2])
      x3=hh[2];
    else if(hh[0]>hh[2])
      x3=hh[2]-1;
    
    if(hh[1]<hh[3])
      y3=hh[3]+1;
    else if(hh[1]==hh[3])
      y3=hh[3];
    else if(hh[1]>hh[3])
      y3=hh[3]-1;
    }
    else
    {
    if(hh[0]<hh[2])
      x3=hh[0]-1;
    else if(hh[0]==hh[2])
      x3=hh[0];
    else if(hh[0]>hh[2])
      x3=hh[0]+1;
    
    if(hh[1]<hh[3])
      y3=hh[1]-1;
    else if(hh[1]==hh[3])
      y3=hh[1];
    else if(hh[1]>hh[3])
      y3=hh[1]+1;
    }
    
    
    if(x3>=0&&x3<=18&&y3>=0&&y3<=18&&qp[x3][y3]==0)
      return;
    
  }
  
  while(s41.empty()==0)
  {
    for(i=0;i<6;i++)
    {
      hh[5-i]=s41.top();
      s41.pop();
    }
    x3=hh[4];
    y3=hh[5];
    if(x3>=0&&x3<=18&&y3>=0&&y3<=18&&qp[x3][y3]==0)
      return;
    
  }
  
  while(s31.empty()==0)
  {
    for(i=0;i<6;i++)
    {
      hh[5-i]=s31.top();
      //nn=s31.top();
      //cout<<"h:"<<nn<<" ";
      s31.pop();
    }
    x3=hh[4];
    y3=hh[5];
    if(x3>=0&&x3<=18&&y3>=0&&y3<=18&&qp[x3][y3]==0)
      return;
    
  }
  
  
  while(s32.empty()==0)
  {
    for(i=0;i<4;i++)
    {
      hh[3-i]=s32.top();
      s32.pop();
    }
    if(hh[0]<hh[2])
      x3=hh[2]+1;
    else if(hh[0]==hh[2])
      x3=hh[2];
    else if(hh[0]>hh[2])
      x3=hh[2]-1;
    
    if(hh[1]<hh[3])
      y3=hh[3]+1;
    else if(hh[1]==hh[3])
      y3=hh[3];
    else if(hh[1]>hh[3])
      y3=hh[3]-1;
      
    if(x3>=0&&x3<=18&&y3>=0&&y3<=18&&qp[x3][y3]==0)
      return;
    
  }
  
  for(i=1;i<=9;i++)
  {
    if(i==5)
      continue;
    k=pd(x,y,i);
    if(k==0)
      f7.push(i);
    else if(k==1||k==3)
      f8.push(i);
    else if(k==2)
    {
      f9.push(i);
      //nn=i;
      //cout<<"i:"<<nn<<endl;
    }
  }
  
  
  while(f9.empty()==0)
  {
    srand(time(0));
    k1=rand()%f9.size();
    for(i=0;i<f9.size();i++)
    {
      k=f9.front();
      f9.pop();
      if(i==k1)
        break;
      else
        f9.push(k);
    }
    switch(10-k)
    {
    case 1:
         x3=x-1;
         y3=y-1;
         break;
    case 2:
         x3=x;
         y3=y-1;
         break;
    case 3:
         x3=x+1;
         y3=y-1;
         break;
    case 4:
         x3=x-1;
         y3=y;
         break; 
    case 5:
         x3=x;
         y3=y;
         break;
    case 6:
         x3=x+1;
         y3=y;
         break; 
    case 7:
         x3=x-1;
         y3=y+1;
         break; 
    case 8:
         x3=x;
         y3=y+1;
         break;
    case 9:
         x3=x+1;
         y3=y+1;
         break;
    }
    if(x3>=0&&x3<=18&&y3>=0&&y3<=18&&qp[x3][y3]==0)
    {
      while(f9.empty()==0)
        f9.pop();
      return;
    }
  }
  while(f7.empty()==0)
  {
    srand(time(0));
    k1=rand()%f7.size();
    for(i=0;i<f7.size();i++)
    {
      k=f7.front();
      f7.pop();
      if(i==k1)
        break;
      else
        f7.push(k);
    }
    switch(10-k)
    {
    case 1:
         x3=x-1;
         y3=y-1;
         break;
    case 2:
         x3=x;
         y3=y-1;
         break;
    case 3:
         x3=x+1;
         y3=y-1;
         break;
    case 4:
         x3=x-1;
         y3=y;
         break; 
    case 5:
         x3=x;
         y3=y;
         break;
    case 6:
         x3=x+1;
         y3=y;
         break; 
    case 7:
         x3=x-1;
         y3=y+1;
         break; 
    case 8:
         x3=x;
         y3=y+1;
         break;
    case 9:
         x3=x+1;
         y3=y+1;
         break;
    }
    if(x3>=0&&x3<=18&&y3>=0&&y3<=18&&qp[x3][y3]==0)
    {
      while(f7.empty()==0)
        f7.pop();
      return;
    }
  }
  
  //return x3,y3
}

char lz(char x,char y,char a)//落子
{
  if(qp[x][y]==0)
  {
    qp[x][y]=a;
    /*mm=x;
    nn=y;
    cout<<endl<<"下"<<mm<<" "<<nn<<endl;*/
    return 1;
  }
  else
    return 0;
} 
int main()
{
  int x0,y0;
  lz(9,9,1);
  cout<<180<<endl;
  
  //qp[9][8]=2;
  //qp[8][8]=2;
  //qp[9][10]=2;
  
  while(0==0)
  {
    
    //cout<<"cin";
    cin>>mn;
    mm=mn%19;
    nn=(mn-mm)/19;
    xx=mm;
    yy=nn;
    //cout<<mm<<nn;
    
    
    bl=lz(xx,yy,2);
    
    
    
    
    if(bl==0)
      continue;
    for(ii=1;ii<=4;ii++)
      lxpd(xx,yy,ii);
    
    //if(s3.empty()==1&&s4.empty()==1&&s31.empty()==1&&s32.empty()==1&&s41.empty()==1)
    //cout<<"perfect"<<endl; 
    //if(s31.empty()==0)
      //cout<<"not empty"<<endl; 
    
    xq1(xx,yy);
    lz(x3,y3,1);
    nm=x3+y3*19;
    cout<<nm<<endl;
    /*cout<<endl<<"hh:";
    for(i=0;i<6;i++)
    {
      nn=hh[i];
      cout<<nn<<" ";
    }
    cout<<endl;*/
    
    cout<<endl;
    //sc();
  }
  
  system("pause");
  return 0;
} 
