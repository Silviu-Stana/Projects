%consult("exam.pl").

%inclus
membru(E,[E|T]) :- !.
membru(E,[X|T]) :- membru(E,T).

inclus([],L2) :- !.
inclus([H|T],L2) :- membru(H,L2), inclus(T,L2).

intersectie([],L2,[]).
intersectie([H|T],L2,[H|TR]) :- membru(H,L2), intersectie(T,L2,TR), !.
intersectie([H|T],L2,TR) :- intersectie(T,L2,TR).