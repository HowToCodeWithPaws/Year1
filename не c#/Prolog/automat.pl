i(s1).
f(s3).
tr(s1,a,s2).
tr(s2,a,s2).
tr(s2,b,s2).
tr(s2,c,s3).
dfa([],s):-f(s).
dfa([H|T],s):-tr(s,H,s1), dfa(T, s1), initial(s).
check([H|T]):-initial(s),dfa([H|T],s).
