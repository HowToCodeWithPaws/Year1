
fact(0,S,S).
fact(N, S, F) :-N>0,N1 is N-1, S1 is S*N, fact(N1, S1, F).
fact(N,F):- fact(N,1,F).
