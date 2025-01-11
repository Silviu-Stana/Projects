membru(X,[X|_]) :- !.
membru(X,[_|T]) :- membru(X,T).

%lungime lista
lungime([],0).
lungime([_|T],NR) :- lungime(T,Y), NR is Y+1.

%suma lista
sum([],0).
sum([H|T], S) :- sum(T,S1), S is S1+H.

sumaPara([], 0).
sumaPara([H|T], S) :- H mod 2 =:= 0, sumaPara(T, S1), S is S1 + H. %Daca H este par, adaugam.
sumaPara([H|T], S) :-  H mod 2 =\= 0, sumaPara(T, S). %Daca H impar, ignoram.


%Max dintr-o lista
maxim([H|T], Max) :-
    max(T, H, Max).

%Functie auxiliara ca sa tine cont de maximul curent
max([], Max, Max).
max([H|T], CurMax, Max) :-
    H > CurMax,
    max(T, H, Max).
max([H|T], CurMax, Max) :-
    H =< CurMax,
    max(T, CurMax, Max).


%Max dintr-o lista de liste
maxime([], []).
maxime([H1|H2], [T1|T2]) :-
    maxim(H1, T1), % Determina maximul din prima sublista
    maxime(H2, T2). % Recursiv pentru restul listelor

  %maxime([[3, 5, 2], [1, 9, 8], [7, 4]], Rezultat).
  %Rezultat = [5, 9, 7]


media([], 0).
media(L, M):- sum(L, S), lungime(L, NR), M is S / NR.

% TEMA EXERCITIU 1: Media maximelor dintr-o lista de liste
exercitiu1(ListaDeListe, Media) :-
    maxime(ListaDeListe, Maxime), % Calculam lista de maxime
    sum(Maxime, Suma),           % Calculam suma maximelor
    lungime(Maxime, Lungime),    % Determinam lungimea listei de maxime
    Lungime > 0,                 % Verificam daca lungimea este mai mare decât 0
    Media is Suma / Lungime.     % Calculam media.


% TEMA EXERCITIU 2: Suma valorilor pare din maximul listelor
exercitiu2(ListaDeListe,SUMA) :-
    maxime(ListaDeListe, Maxime),
    sumaPara(Maxime,SUMA).

    %exemplu apelare: suma_valorilor_pare([[3, 5, 10], [1, 9, 8], [1, 4]], SUMA).
%SUMA = 14





%TEMA EXERCITIU 3: Concatenarea n liste, si apoi media aritmetica.
% adauga cate 1 element, pana cand lista 1 este vida, apoi adauga toata
% lista 2
concatenare([],L2,L2).
concatenare([H1|T1], L2, [H1|TR]) :- concatenare(T1,L2,TR).

%Concatenarea lista de liste
concatListe([], []).
concatListe([H|T], Rezultat) :-
    concatListe(T, Partial), %Concateneaza restul listelor recursiv.
    concatenare(H, Partial, Rezultat).



exercitiu3(Liste, ListaConcatenata, Media) :-
    concatListe(Liste,ListaConcatenata),
    media(ListaConcatenata,Media).
%Exemplu de apel:
%exercitiu3([[1,2], [3,4,5], [3]], ListaConcatenata,Media).


exercitiu4(Liste,ListaConcatenata,NrPare, NrImpare):-
    concatListe(Liste,ListaConcatenata),
    lungimePareImpare(ListaConcatenata,NrPare, NrImpare).

%nr valori pare/impare din lista
lungimePareImpare([],0,0).
lungimePareImpare([H|T],NrPare,NrImpare) :- H mod 2 =:= 0, lungimePareImpare(T,NR,NrImpare), NrPare is NR+1.
lungimePareImpare([H|T],NrPare,NrImpare) :- H mod 2 =:= 1, lungimePareImpare(T,NrPare,NR), NrImpare is NR+1.
%Ex de apel:
%exercitiu4([[1,2], [3,4,5], [3]], ListaConcatenata,Pare,Impare).


medii([],[]).
medii([H1|H2],[T1|T2]) :-
    media(H1,T1),
    medii(H2, T2).


%Exemplu apel, calcul_medii_elevi:
%exercitiu5([[8,9,7], [10,9], [7,9,6,2,8]], LM).
%Rezultat: LM = [8, 9.5, 6.4].
exercitiu5(Liste,MediiStudenti) :-
    medii(Liste,MediiStudenti).



mediiPromovate([],[]).
mediiPromovate([H1|H2],[T1|T2]) :- %daca >5, o adaugam
    media(H1,T1),
    T1>5,
    mediiPromovate(H2, T2).
mediiPromovate([H1|H2],T2) :- %altfel, trecem mai departe
    media(H1,T1),
    T1=<5,
    mediiPromovate(H2, T2).


mediiRestante([],[]).
mediiRestante([H1|H2],[T1|T2]) :- %daca <=5, o adaugam
    media(H1,T1),
    T1=<5,
    mediiRestante(H2, T2).
mediiRestante([H1|H2],T2) :- %altfel, trecem mai departe
    media(H1,T1),
    T1>5,
    mediiRestante(H2, T2).




%EXERCITIU 6 Suplimentar:
lista_medii_promovati(Liste,MediiPromovati,MediiRestante) :-
    mediiPromovate(Liste,MediiPromovati),
    mediiRestante(Liste,MediiRestante).

