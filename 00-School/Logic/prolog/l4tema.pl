%Exercitiu 1:
b(0, 1). b(1, 2).
% Functioneaza decat daca folosim N-1 si N-2,
% nu functioneaza cu cerinta data de N+1 si N+2 care creste la infinit
b(N, S) :- N > 1, N1 is N - 1, N2 is N - 2, b(N1, S1), b(N2, S2), S is (S1 - S2)/2.

%Exercitiu 2:
c(0,1). c(1,-1).
c(N,S) :- N1 is N-1, N2 is N-2, c(N1,R1), c(N2, R2), S is 3*R1 - R2.

e1(N,REZ) :- b(N,R1), c(N,R2), REZ is R1+R2.

%b de 2 = 0.5
%c de 2 = -4
%e1 de 2 = -3.5