%Calc media aritmetica in lista
ma([],0,0,0).
ma([H|T],S,L,Ma) :- ma(T,S1,L1,Ma1), S is S1+H, L is L1+1, Ma is S/L.

%Diferenta a 2 liste
dif([],L,[]).
dif([H1|T1],L2,[H1|TR]) :- not(member(H1,L2)), dif(T1,L2,TR).
dif([H1|T1], L2, LR) :- member(H1,L2), dif(T1,L2,LR).


max(H1,H2,H1) :- H1>H2,!.
max(_,H2,H2).

maxL([H],[H]).
maxL([H|T],MAX) :- maxL(T,MAX2), max(H,MAX2, MAX).

maxL2([H],H).
maxL2([H|T], Max) :- maxL2(T,Max1), (H>=Max1, Max is H ; H<Max1, Max is Max1).

