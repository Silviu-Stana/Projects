% Definire lista: [H|T] (Head|Tail)
% [1,2,3,4,5]
% Head is 1. Tail is 2,3,4,5
%
% [X|Y] = [doar, un, exemplu]
%
% X=doar
% Y=[un, exemplu]
%
% [X,Y|Z] = [a,b,c,d] =>true
% X=a, Y=b, Z=lista [c,d]
%
%[X|Y] = [] => fals
%
%[X|Y] = [[a,[b,c]],d] => true
%X=[a,[b,c]]
%Y=d
%
%
%[X|Y]=[a] => true
%X=a
%Y=[]
%
%
%Definition: lista=integer*


%Ex1: apare un element in lista?
%X in L, L=[H1,H2,H3,....]

%[X trateaza cazul in care capul cozii este chiar X
membru(X,[X|T]) :- !.
%altfel
membru(X,[H|T]) :- membru(X,T).

%L=[7,10,11,3]
%membru(11, [7|10,11,3]) fals
%membru(11,[10|11,3]) fals
%membru(11, [11|3]) true
%operatorul !. spune ca opresc

%membru(7,[3,7,-2,5,0]).
%true.
%membru(6,[3,7,-2,5,0]).
%false.


%Ex2: lungime lista
lungime([],0).
lungime([H|T],NR) :- lungime(T,Y), NR is Y+1.

%lungime([3,4,6],NR).
%NR = 3.

%Ex3: sum el lista
sum([],0).
sum([H|T], S) :- sum(T,S1), S is S1+H.


%Ex4: concatenare 2 liste
%
%rezultatul de concatenare din lista vida si lista2 este chiar lista2
concatenare([],L2,L2).
% adauga 1 element cate 1 element, pana cand lista 1 este vida, apoi
% adauga toata lista 2
concatenare([H1|T1], L2, [H1|TR]) :- concatenare(T1,L2,TR).
%concatenare([2,1,3],[2,1,7],TR).
%TR = [2, 1, 3, 2, 1, 7].
