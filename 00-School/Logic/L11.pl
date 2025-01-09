%Ex1: PRODUS SCALAR 2 VECTORI
produs([],[],0).
produs([H1|T1], [H2|T2], S) :-
    produs(T1,T2,R1), S is H1*H2+R1.

%Ex2: Vector*Matrice
inmultireVM(V,[],[]).
inmultireVM(V,[HM|TM],[HR|TR]) :-
    produs(V,HM,HR),
    inmultireVM(V,TM,TR).
%inmultireVM([1,2], [[2,1],[1,3],[4,2]],R). => [4,7,8]



%Ex3: Matrice1*Matrice2
inmultireM([],_,[]).
inmultireM([HM1|TM1],M2,[HR|TR]) :-
    inmultireVM(HM1,M2,HR), %fiecare linie inmultita cu matricea
    inmultireM(TM1,M2,TR). %conditia recursiva de continuare
% Apel: inmultireM([[1,2],[2,1]],[[2,1],[1,3],[4,2]],R) => R = [[4, 7,
% 8], [5, 5, 10]]

