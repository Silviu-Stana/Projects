:- style_check(-singleton).
%  consult("l1.pl").

% KNOWLEDGE
% a. Magic SRL: PC si accesorii
% b. Alfa SRL: TV si PC
% c. Beta SA: accesorii

% Cerinte:
% Vinde b. PC? 

% domains
%   nume_firma=symbol
%   nume_produs=symbol
% predicates
%   vinde(nume_firma, nume_produs)
% clauses
%   vinde(magicsrl, pc)
%   vinde(magicsrl, accesorii)

vinde(magicSRL, pc).
vinde(magicSRL, accesorii).
vinde(alfaSRL, tv).
vinde(alfaSRL, pc).
vinde(betaSRL, accesorii).

% Vinde pc?
?- vinde(alfaSRL, pc). % true

% Ce vinde?
?- vinde(magicSRL, X).

% Cine vine pc?
?- vinde(X, pc)

% Vinde alfa ceva?
?- vinde(alfaSRL, X)

?- vinde(alfaSRL,_) %vinde ceva? - true

?- vinde(_,accesorii) %vinde cineva? -true

?- vinde(X,Y) %cand apesi ; afiseaza urmatorul rezultat

?- vinde(_,_) %vinde cineva ceva

% cine vinde la fel ca betaSRL un anumit produs?
?- vinde(betaSRL,X),vinde(Y,X),Y\=betaSRL %exclude betaSRL din rezultate


% TEMA: alex vinde trandafiri, lalele, crizanteme
% ana vinde lalele si crini
% vinde andrei lalele

% 1. Vinde andrei lalele?
% 2. Cine vinde crizanteme?
% 3. Ce vinde ana?
% 3. Vinde cineva crini?
% 5. Vinde andu ceva?
% 6. Cine vinde la fel ca alex un anumit produs?
% 7. Ce vinde andu si nu este floare? (nuci)

