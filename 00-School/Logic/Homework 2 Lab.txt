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



%Exercitiu 3:
cmmdc(X,Y,Y) :- mod(X,Y) =:= 0,!.
cmmdc(X,Y,D) :- R is mod(X,Y), cmmdc(Y,R,D).

cmmmc(X,Y,M) :- cmmdc(X,Y,D), M is X*Y/D.

cmmdc3(A,B,C,R) :- cmmdc(A,B,R1), cmmdc(R1,C,R).

   %calculul final
e2(X,Y,Z,T,FINAL) :-
	cmmdc(X,Y,R1), cmmdc(R1,Z,R2), cmmdc(R2,T,R3), %(X+Y+Z+T) //1

	cmmmc(Z,T,M0), %M0 reprezinta [z,t] //2
	cmmmc(X,Y,M1), cmmmc(M1,Z,M2),  %M2 reprezinta [X,Y,Z] //6

	cmmdc(Y,Z,C1), cmmdc(C1,T,C2), %C2 reprezinta (Y,Z,T) //1

	cmmmc(R1,M0-M2,F1), cmmmc(F1,M2,F2), cmmmc(F2,C2,F3), %F3 - Reprezinta calculul din toate de mai sus
        FINAL is R3+F3.
