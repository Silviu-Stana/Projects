% consult("exam.pl").

triplete(K,[],[]).
triplete(K,[t(N1,N2,N3)|T], [t(N1,N2,N3)|TR]) :- N3<(K-1)*(K-1), triplete(K,T,TR), !.
triplete(K,[t(N1,N2,N3)|T], TR) :- triplete(K,T,TR).