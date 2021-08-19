from __future__ import division
import numpy as np
import matplotlib.pyplot as plt
import math

import pickle

with open('tuning.pickle', 'rb') as f:
    data = pickle.load(f)
    
with open('coding.pickle', 'rb') as f:
    coding = pickle.load(f)
    

num = len(data['stim'])

n1stat = np.zeros((num,))
n2stat = np.zeros((num,))
n3stat = np.zeros((num,))
n4stat = np.zeros((num,))

i = 0
while i < num:
    for k in range(100):
        n1stat[i]=n1stat[i]+data['neuron1'][k][i]
        n2stat[i]=n2stat[i]+data['neuron2'][k][i]
        n3stat[i]=n3stat[i]+data['neuron3'][k][i]
        n4stat[i]=n4stat[i]+data['neuron4'][k][i]
    i=i+1
    
n1stat = n1stat*0.01
n2stat =n2stat*0.01
n3stat =n3stat*0.01
n4stat =n4stat*0.01

#plt.plot(data['stim'], n1stat)
#plt.xlabel('stim')
#plt.ylabel('respond')
#plt.title('neuron1')

#plt.show()

#plt.plot(data['stim'], n2stat)
#plt.xlabel('stim')
#plt.ylabel('respond')
#plt.title('neuron2')

#plt.show()

#plt.plot(data['stim'], n3stat)
#plt.xlabel('stim')
#plt.ylabel('respond')
#plt.title('neuron3')

#plt.show()

#plt.plot(data['stim'], n4stat)
#plt.xlabel('stim')
#plt.ylabel('respond')
#plt.title('neuron4')

#plt.show()

r1max = max(n1stat)
r2max = max(n2stat)
r3max = max(n3stat)
r4max = max(n4stat)

#print(r1max, r2max, r3max, r4max)


#print(coding.keys())
#print(coding['c1'])
#print(coding['c2'])
#print(coding['c3'])
#print(coding['c4'])
#print(coding['r1'])
#print(coding['r2'])
#print(coding['r3'])
#print(coding['r4'])

r1 =r2=r3=r4= 0

for n in range(10):
    r1 = r1 + coding['r1'][n]
    r2 = r2 + coding['r2'][n]
    r3 = r3+ coding['r3'][n]
    r4 = r4 + coding['r4'][n]
    
r1 = r1/10
r2 = r2/10
r3 = r3/10
r4 = r4/10

#print(r1)

summ1=r1/r1max*coding['c1']
summ2= r2/r2max*coding['c2']
summ3=r3/r3max*coding['c3']
summ4=r4/r4max*coding['c4']

summ = summ1+summ2+summ3+summ4

print(summ1, summ2, summ3, summ4, summ)

# options 1 and 2 who knows
print(np.rad2deg(math.atan(summ[1]/summ[0])))

plt.scatter(summ[0], summ[1])
plt.xlabel('cos')
plt.xlim((-1,1))
plt.ylabel('sin')
plt.ylim((-1,1))
plt.title('option 1')

plt.show()
#292

print(np.rad2deg(math.atan(summ[0]/summ[1])))
plt.scatter(summ[1], summ[0])
plt.xlabel('cos')
plt.xlim((-1,1))
plt.ylabel('sin')
plt.ylim((-1,1))
plt.title('option 2')

plt.show()
#338

plt.scatter(math.cos(np.deg2rad(292)), math.sin(np.deg2rad(292)))
plt.xlabel('cos')
plt.xlim((-1,1))
plt.ylabel('sin')
plt.ylim((-1,1))
plt.title('check1')

plt.show()

plt.scatter(math.cos(np.rad2deg(math.atan(summ[0]/summ[1]))), math.sin(np.rad2deg(math.atan(summ[0]/summ[1]))))
plt.xlabel('cos')
plt.xlim((-1,1))
plt.ylabel('sin')
plt.ylim((-1,1))
plt.title('check2')

plt.show()

plt.scatter(0.92964665, -0.37925099)
plt.xlabel('cos')
plt.xlim((-1,1))
plt.ylabel('sin')
plt.ylim((-1,1))
plt.title('what the fuck')

plt.show()


print(0.92964665/-0.37925099)