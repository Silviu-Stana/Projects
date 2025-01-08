%EXERCITIU SUPLIMENTAR 1
e1(X, Y, Result) :-
    X > 2, Y > 1, !,
    Result is X + Y - 1.
e1(X, Y, Result) :-
    Result is X - Y + 1.


%EXERCITIU SUPLIMENTAR 2
e2(X, Y, Z, T, Result) :-
    X > 2, Y > 2, Z > 1, T > 1, !,
    Result is X + Y + Z + T.
e2(X, Y, Z, T, Result) :-
    X > 2, Y > 2, Z < -1, T < -1, !,
    Result is X + Y - Z - T.
e2(X, Y, Z, T, Result) :-
    Result is X - Y + Z + T.


max(X,Y,X):- X >= Y.
max(X,Y,Y):- Y > X.
min(X,Y,X) :- X =< Y.
min(X,Y,Y) :- Y < X.



%EXERCITIU SUPLIMENTAR 3
e3(X, Y, Result) :-
    Max is max(X, Y),
    Min is min(X, Y),
    e1(X, Y, E1Result),
    Result is Max - Min + E1Result.
