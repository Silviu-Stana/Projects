%1 Calc:
f(X,Y,R) :-  X>(-1), Y<1, R is (X+Y-2),!.
f(X,Y,R) :- R is X-Y.
g(X,Y,R) :- R is X*X - Y*Y.
e(X,Y,R) :- f(X,Y,R1), g(X,Y,R2), R is R1+3*R2.

%2 CMMDC / CMMMC
cmmdc(X,Y,Y) :- mod(X,Y) =:= 0,!.
cmmdc(X,Y,D) :- R is mod(X,Y), cmmdc(Y,R,D).

cmmmc(X,Y,M) :- cmmdc(X,Y,D), M is X*Y/D.

%3 Calc
h(A,B,C,R) :- cmmdc(A,C,R1), cmmmc(A,B,R2), cmmdc(B,C,R3), R is R1-R2+R3.


%4 Calc
cmmdc3(A,B,C,R) :- cmmdc(A,B,R1), cmmdc(R1,C,R).

%5 Calc
max(A,B,REZ) :- A>=B, REZ is A,!.
max(A,B,REZ) :- REZ is B.

maxc(A,B,C,M) :- cmmdc(A,C,R1), cmmmc(A,B,R2), cmmdc(B,C,R3), max(R1,R2,REZ1), max(REZ1,R3,M).