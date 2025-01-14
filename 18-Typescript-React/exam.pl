%consult("exam.pl").


max(X,Y,X) :- X>=Y, !.
max(X,Y,Y).

lungime([],0).
lungime([H|T],NR) :- lungime(T,NR1), NR is NR1+1.

suma([],0).
suma([H|T],S) :- suma(T,S1), S is S1+H.

media([],0).
media(L,Media) :- lungime(L,NR), suma(L,S), Media is S/NR.


% media([],0,0,0).
% media([H|T],S,L,M) :- media(T,S1,L1,M1), S is S1+H, L is L1+1, M is S/L.

mediaListe([],[]).
mediaListe([H1|H2],[T1|T2]) :- media(H1,T1), mediaListe(H2,T2).

concatenareListe([],[]).
concatenareListe([H|T],Rezultat) :- concatenare(H,TPartial), concatenareListe(TPartial,Rezultat)