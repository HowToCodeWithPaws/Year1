even(0).
even(N):- N1 is N-1,N1>=0, odd(N1).
odd(N):-N1 is N-1,N1>=0, even(N1).


loves(gabriel, X):- snake(X), !, fail.
loves(gabriel, X):-animal(X).

animal(X):-dog(X).
animal(X):-cat(X).
animal(X):-horse(X).
animal(X):-snake(X).
animal(X):-elephant(X).
elephant(dumbo).
snake(crowley).
dog(dog).
cat(mitten).
horse(bo).


brother(X,Y):-parent(Z,X), parent(Z, Y), male(X), different(X,Y).
different(X,X):-!, fail.
different(X,Y).
male(pat).
parent(amy, pat).
parent(amy, may).

replace([],[]).
replace(a|T)
replace(X,1):-atomic(X), .
replace([H|T],S):-replace(H,S1), replace(T, S2).
