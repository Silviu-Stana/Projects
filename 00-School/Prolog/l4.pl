factorial(0,1).
factorial(N,R) :- N1 is N-1, factorial(N1,R1), R is R1*N.


%an = 2*(an-1)+1
a(0,-2).
a(N,S) :- N1 is N-1, a(N1,R1), S is 2*R1+1.

%Fibonacci
fib(0,0).
fib(1,1).
fib(N,S) :- N1 is N-1, N2 is N-2, fib(N1,R1), fib(N2,R2),  S is R1+R2.


%Suma de n nr
sum(0,0).
sum(1,1).
sum(N,S) :- N1 is N-1, sum(N1,R1),  S is R1+N.

f(0,-1).
f(1,2).
f(N,R) :- N1 is N-1, N2 is N-2, f(N1,R1), f(N2,R2), R is 2*R1-3*R2.


pow(_,0,1).
pow(0,X,0).
pow(N,X,R) :- X1 is X-1, pow(N,X1,R1), R is R1*N.

%Tema: gallery photo
