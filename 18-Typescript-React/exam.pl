%consult("exam.pl").


count(E, [], 0).
count(E, [E|T], NR):- count(E, T, NR1), NR is NR1 + 1.
count(E, [H|T], NR):- count(E, T, NR).

