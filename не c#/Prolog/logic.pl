lp(X):-d(X), lc(X).
d(a).
lc(a).

r(X):-c(X).
f(X):-c(X).
o(a).
c(a).

quadruped(X):- human(X), !, fail.
human(X):-man(X).
man(a).
