%Divide in 2 lists based on >=k and <k
divK([],_,[],[]).
divK([H|T], K, [H|TPOZ], L2) :- H>=K, divK(T, K, TPOZ, L2),!.
divK([H|T], K, L1, [H|TNEG]) :- divK(T,K,L1,TNEG).


lungime([], 0).
lungime([_|T], X):- lungime(T, Y), X is Y + 1.
suma([], 0).
suma([H|T], S):- suma(T, S1), S is S1 + H.
media_aritmetica([], 0).
media_aritmetica(L, M):- suma(L, S), lungime(L, X), M is S / X.

%Interclasare
order(L,[], L).
order([],L,L).
order([H1|T1], [H2|T2], [H1|T]) :- H1=<H2, order(T1,[H2|T2], T),!.
order([H1|T1], [H2|T2], [H2|T]) :- order([H1|T1], T2, T).

