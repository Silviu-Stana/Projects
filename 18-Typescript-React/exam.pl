%consult("exam.pl").


% b(n) = b(n-1)-2*b(n-2)
b(0,-1).
b(1,2).
b(N,R) :- N1 is N-1, N2 is N-2, b(N1,R1), b(N2,R2), R is R1-2*R2.