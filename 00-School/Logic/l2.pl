:- style_check(-singleton).
%  consult("l2.pl").
barbat(X).
femeie(X).
parinte(X,Y).
diferit(X,Y).
este_mama(X) :- femeie(X) , parinte(X,_).
este_tata(X) :- barbat(X) , parinte(X,_).
este_fiu(X) :- barbat(X), parinte(_,X).
sora(X,Y) :- femeie(X), parinte(Z,X), parinte(Z,Y), diferit(X,Y).
bunic(X,Y) :- barbat(X), parinte(X,Z), parinte(Z,Y).
frati(X,Y) :- parinte(Z,X), parinte(Z,Y).

%! Calcul medie 2 nr
media_aritmetica(A,B,MA) :- MA is (A+B)/2.
% ! Conditiile sunt executate in ordine, de la stanga la dreapta. De
% aceea diviziunea cu 0 se face prima.
media_armonica(A,B,M) :- A\=0, B\=0, M is 2/(1/A + 1/B).

%!  Determina max/min 2 nr
max(A,B,A) :-  A>=B.
max(A,B,B) :- B>A.
min(A,B,A) :- A=<B.
min(A,B,B) :- B<A.

%!  Operatorul cut "!", urmatoare linie va fii ca un "else"
maxim(A,B,A) :- A>=B, !.
maxim(A,B,B).

%!  Max din 3 nr
maxim3(A,B,C,MAX3) :- maxim(A,B,X), maxim(X,C,MAX3).

maxim4(A,B,C,MAX3) :- maxim(A,B,X), maxim(X,C,MAX3).

% f(X,Y) = X+Y-2, daca X>-1, Y<1 altfel X-Y
f(X,Y,REZ) :-  X>(-1), Y<1, REZ is X+Y-2,!.
f(X,Y,REZ) :- REZ is X-Y.
