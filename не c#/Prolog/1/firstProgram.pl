woman(tamara).
woman(zoe).
woman(lidia).
woman(elena).
woman(irina).
woman(ludmila).
woman(maia).
woman(taisia).
woman(svetlana).
man(dmitrii).
man(maxim).
man(eli).

parent(zoe,lidia).
parent(zoe,elena).
parent(elena,ludmila).
parent(lidia,irina).
parent(irina,maia).
parent(irina,taisia).
parent(irina,eli).
parent(tamara,dmitrii).
parent(tamara,maxim).
parent(dmitrii,eli).
parent(maxim,svetlana).

sibling(X,Y):-parent(Z,X),parent(Z,Y).

sister(X,Y):-sibling(X,Y),woman(X).
brother(X,Y):-sibling(X,Y),man(X).

mother(X,Y):-parent(X,Y),woman(X).
father(X,Y):-parent(X,Y),man(X).

aunt(X,Y):-parent(Z,Y),sister(X,Z).
uncle(X,Y):-parent(Z,Y),brother(X,Z).

grandparent(X,Y):-parent(X,Z),parent(Z,Y).
grandmother(X,Y):-grandparent(X,Y),woman(X).
grandfather(X,Y):-grandparent(X,Y),man(X).

cousin(X,Y):-parent(Z,Y),parent(W,X),sibling(Z,W).
cousinM(X,Y):-cousin(X,Y),man(X).
cousinF(X,Y):-cousin(X,Y),woman(X).

