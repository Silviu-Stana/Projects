multipLL(K,[],[]).
multipLL(K,[HL|TL],[HR|TR]) :-
      multipL(K,HL,HRez),
      qsort(HRez,HSortat),
      inversare(HSortat,[],HR),
      multipLL(K,TL,TR).
      
multipL(K,[],[]).
multipL(K,[H|T],[HR|TR]) :- H mod 2 =:= 0, HR is H*(3*K-2), multipL(K,T,TR), !.
multipL(K,[H|T], [H|TR]) :- multipL(K,T,TR).

split(_,[],[],[]).
split(E,[H|T],[H|T1],T2) :- H=<E, split(E,T,T1,T2), !.
split(E,[H|T],T1,[H|T2]) :- split(E,T,T1,T2).

concatenare([],L2,L2).
concatenare([H1|T1],L2,[H1|TR]) :- concatenare(T1,L2,TR).

qsort([],[]).
qsort([H|T],Lsort) :-
      split(H,T,L1,L2),
      qsort(L1,R1),
      qsort(L2,R2),
      concatenare(R1,[H|R2],Lsort).

executie(K,LL,Rezultat,RSortat) :-
      multipLL(K,LL,Rezultat).

inversare([], L, L).
inversare([H|T], Temp, I):- inversare(T, [H|Temp], I).
invers(L, I):- inversare(L, [], I).

      
      % multipLL(1,[[1,3,2],[2,4,6],[1,3,5]],Rezultat).