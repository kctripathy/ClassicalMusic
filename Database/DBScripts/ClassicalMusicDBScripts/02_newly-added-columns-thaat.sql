--ALTER TABLE Thaat ADD Aroh NVARCHAR(50); --new
--ALTER TABLE Thaat ADD Avroh NVARCHAR(50); --new

select * from thaat
/*
UPDATE Thaat SET ThaatName=N'Bilawal', ThaatDesc=N'Bright, joyful, natural notes (shuddha swaras)',Aroh=N'S R G M P D N ?', Avroh=N'? N D P M G R S' WHERE ID=1
UPDATE Thaat SET ThaatName=N'Kalyan', ThaatDesc=N'Serene, devotional, with brilliance (teevra Ma)',Aroh=N'S R G ? P D N ?', Avroh=N'? N D P ? G R S' WHERE ID=2
UPDATE Thaat SET ThaatName=N'Khamaj', ThaatDesc=N'Romantic, sensuous (komal Ni)',Aroh=N'S R G M  P D n ?', Avroh=N'? n D P M G R S' WHERE ID=3
UPDATE Thaat SET ThaatName=N'Kafi', ThaatDesc=N'Folk-like, soulful (komal Ga, Ni)',Aroh=N'S R g M P D n ?', Avroh=N'? n D P M g R S' WHERE ID=4
UPDATE Thaat SET ThaatName=N'Asavari', ThaatDesc=N'Emotional, serious (komal Ga, Dha, Ni)',Aroh=N'S R g M P d n ?', Avroh=N'? n d P M g R S' WHERE ID=5
UPDATE Thaat SET ThaatName=N'Bhairav', ThaatDesc=N'Austere, meditative (komal Re, Dha)',Aroh=N'S r G M P d N ?', Avroh=N'? N d P M G r S' WHERE ID=6
UPDATE Thaat SET ThaatName=N'Bhairavi', ThaatDesc=N'Devotional, pathos-filled (4 komal swaras)',Aroh=N'S r g M P d n ?', Avroh=N'? n d P M g r S' WHERE ID=7
UPDATE Thaat SET ThaatName=N'Marwa', ThaatDesc=N'Intense, serious (komal Re, teevra Ma)',Aroh=N'S r G ? P D N ?', Avroh=N'? N D P ? G r S' WHERE ID=8
UPDATE Thaat SET ThaatName=N'Poorvi', ThaatDesc=N'Mysterious, grave (komal Re, Dha + teevra Ma)',Aroh=N'S r G ? P d N ?', Avroh=N'? N d P ? G r S' WHERE ID=9
UPDATE Thaat SET ThaatName=N'Todi', ThaatDesc=N'Complex, poignant (komal Re, Ga, Dha + teevra Ma)',Aroh=N'S r g ? P d N ?', Avroh=N'? N d P ? g r S' WHERE ID=10
*/

INSERT INTO Raaga(RaagaName,Jati,RaagaTime,Mood,Aroh,Avroh,Pakad,Vadi,Samvadi,NyasaSwara,RaagaDesc, ThaatId) 
VALUES 
(N'Jog',N'Audav–Shadav',N'Late night (2nd prahar of night)',N'Romantic, Mysterious',N'S G M P n ?',N'? n P M G M g S',N'G M P, n P, M G M g S',N'M',N'S',N'M S n',N'Jog is special because it uses both shuddha and komal Ga, giving it a unique and haunting sweetness.',4)


INSERT INTO Raaga(RaagaName,Jati,RaagaTime,Mood,Aroh,Avroh,Pakad,Vadi,Samvadi,NyasaSwara,RaagaDesc, ThaatId) VALUES 
(N'Bhupali',N'Audav–Audav',N'Evening (1st prahar of night, 6–9 pm)',N'Peaceful, Devotional',N'S R G P D ?',N'? D P G R S',N'G R, G P, D P, G R S',N'G',N'D',N'G D S',N'Raag Bhupali is a serene pentatonic raga of the Kalyan thaat, evoking devotion and peace with its simple yet majestic structure. It omits Ma and Ni, and rests mainly on Ga, Dha, and Sa, giving it a prayerful and meditative character.',1),
(N'Bhimpalasi',N'Audav–Sampurna',N'Afternoon (2nd prahar, around 12–3 pm)',N'Romantic, Devotional, Viraha',N'? S g M P n ?',N'? n D P M g R S',N'? S, g M P, n ?; P M g R S',N'M',N'S',N'M S n',N'Raag Bhimpalasi is a soulful afternoon raga of Kafi thaat, filled with devotion and longing.Its essence lies in the plaintive use of komal Ga and Ni, with repose on Ma and Sa.',4),
(N'Shivaranjani ',N'Audav–Audav',N'2nd Prahar of the Night (9PM to 12AM) or Midnight',N'Sad, Devotional, Romantic',N'S R g P D ?',N'? D P g R S; R, ? S',N'R g P ; D P g R ; g S R D S ;',N'P',N'S',N'P S',N'Raag Shivranjani is a very melodious and straightforward Raag. This Raag is similar to Raag Bhoopali but has Gandhar Komal instead of Shuddha Gandhar. It can be expanded freely in all the three octaves.',4),
(N'Hansdhwani',N'Audhav-Audhav',N'2nd Prahar of the Night (9PM to 12AM)',N'',N'S R G P N ?',N'? N P G R S ?, P ? R S',N'? RG P G R G P N ?; ? N P G R G P G R S;',N'S',N'P',N'G P N - ? N P G;',N'Madhyam and Dhaivat Varjya. Rest all Shuddha Swaras.',1),
(N'Pilu',N'Audhav-Sampurna',N'3rd Prahar of the Day (12PM to 3PM)',N'Devotional, Piety',N'S G M P N ?',N'? n D P M g R S ; ,N S g R S ;',N'G M P N ? ; n D P ; M P N d P ; M g R S ; P g R S ,N ; S g R S ;',N'G',N'N',N'S G P N',N'Rishabh and Dhaivat Varjya in Aaroh. Both Gandhars, Both Dhaivats, Both Nishads. Rest all Shuddha Swaras. In this Raag Komal Nishad is used with Shuddha Dhaivat and Shuddha Nishad is used with Komal Dhaivat. This Raag is expandable in Mandra and Madhya Octaves.',4),
(N'Durga',N'Audhav-Audhav',N'2nd Prahar of the Night (9PM to 12AM)',N'Cheerful, Devotional',N'S R M P D ?',N'? D P D M R S ? S',N'M P D ; M R ? S ; R R P;',N'M',N'S',N'M P D',N'Gandhar and Nishad Varjya. Rest all Shuddha Swaras.',1)

select * from Raaga

select * from Thaat

select * from AppImages
select * from Artist

ALTER TABLE Artist ADD ImageUrl VARCHAR(250);
ALTER TABLE Artist ADD IsFamous BIT DEFAULT(1);
ALTER TABLE Artist ADD BirthDeathYear NVARCHAR(10);
ALTER TABLE Artist ADD BriefDesc NVARCHAR(250);