:- style_check(-singleton).
%  consult("l0.pl").

%DATA TYPES:
% 1 Simple: int, float, symbol, userDefined
% 2 Complexe: (forma generala a unui program)
% A. Constants
% B. Domains
% C. Predicates: nume_predicat(arg1, arg2, ..., arg n)
% D. Clauses: nume_clauza(arg1, arg2...)

%E. Fapt: mama(maria, ana) -> maria este mama anei
%F. Regula: parinte(x,y) :- mama(x,y).   ->  x parintele lui y DACA x mama lui y (mereu la final de clauza pune punct)
% ?- mama(maria, ana)   -> este maria mama anei? true
% - mama(x, ana)  -> lista 

% :- (,) dupa este "si" logic
% :- (;) este "sau" logic
% clauza0 :- clauza1 clauza2

% inegalitate: <> sau /=