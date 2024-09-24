-- Dados gerados pelo ChatGPT
INSERT INTO Categorias (nome_categoria) 
VALUES 
('Física'),
('Biologia'),
('Química'),
('Astronomia'),
('Tecnologia');

INSERT INTO FormularioTema (nome, email, tema, id_categoria) 
VALUES 
('Carlos Souza', 'carlos.souza@email.com', 'O impacto da física quântica no cotidiano', 1), 
('Ana Oliveira', 'ana.oliveira@email.com', 'A evolução dos sistemas biológicos no ambiente urbano', 2),
('João Santos', 'joao.santos@email.com', 'Avanços recentes na química ambiental', 3),
('Mariana Lima', 'mariana.lima@email.com', 'A origem e evolução do universo', 4),
('Pedro Almeida', 'pedro.almeida@email.com', 'Inovações tecnológicas na medicina', 5);

INSERT INTO FormularioArtigo (nome, email, titulo, conteudo, id_categoria) 
VALUES 
('Fernanda Silva', 'fernanda.silva@email.com', 'O poder dos aceleradores de partículas', 'Uma discussão sobre o impacto dos aceleradores de partículas em nossa compreensão da física.', 1), 
('Ricardo Pereira', 'ricardo.pereira@email.com', 'A genética no combate a doenças', 'Como os avanços em genética têm contribuído para a cura de doenças complexas.', 2),
('Juliana Costa', 'juliana.costa@email.com', 'Novos materiais para a química sustentável', 'Estudos recentes sobre compostos químicos que podem revolucionar o desenvolvimento sustentável.', 3),
('Lucas Matos', 'lucas.matos@email.com', 'Exploração do sistema solar', 'Uma análise das missões espaciais e os principais desafios da exploração interplanetária.', 4),
('Paula Nunes', 'paula.nunes@email.com', 'Tecnologia de impressão 3D em próteses', 'Como a impressão 3D está revolucionando a criação de próteses mais acessíveis.', 5);

INSERT INTO Artigos (data, titulo, conteudo, nome, id_categoria) 
VALUES 
('2024-01-15T10:00:00', 'A Teoria das Cordas: uma revolução na física', 
'Este artigo explora os fundamentos da Teoria das Cordas, uma proposta revolucionária na física teórica. A teoria sugere que as partículas fundamentais do universo não são pontos, mas sim pequenas cordas vibrantes que oscilam em diferentes modos. Esta visão alternativa tenta unir a mecânica quântica e a relatividade geral, oferecendo uma possível solução para o problema da gravidade quântica. A teoria das cordas também sugere a existência de dimensões adicionais além das conhecidas quatro dimensões do espaço-tempo. Vamos discutir como essa teoria pode resolver problemas antigos e abrir novas possibilidades para a física moderna. A análise abrange desde a origem da teoria até suas implicações para a física de partículas e cosmologia.', 
'Carlos Souza', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Física')),

('2024-02-28T14:30:00', 'A vida artificial e seus impactos futuros', 
'A vida artificial representa uma nova fronteira na biologia e na tecnologia. Este artigo examina os avanços recentes na criação de organismos artificiais em laboratório, incluindo a engenharia genética e a síntese de vida a partir de componentes químicos básicos. A vida artificial pode redefinir o conceito de vida e trazer implicações profundas para a biotecnologia, a medicina e a ética. Discutiremos as técnicas atuais usadas para criar vida artificial, os desafios enfrentados, e as possíveis aplicações, como novos métodos de produção de medicamentos e soluções para problemas ambientais. O artigo também considera as implicações éticas de criar e manipular organismos artificiais.', 
'Ana Oliveira', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Biologia')),

('2024-03-10T09:15:00', 'A Química e as Mudanças Climáticas', 
'As mudanças climáticas são um dos maiores desafios...', 
'João Santos', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Química')),

('2024-04-20T16:45:00', 'O Telescópio James Webb: a nova era da astronomia', 
'O Telescópio Espacial James Webb é um dos avanços mais significativos na observação astronômica desde o Hubble. Este artigo explora as capacidades do James Webb, incluindo sua habilidade de observar o universo em comprimentos de onda infravermelhos, o que permite visualizar objetos distantes e antigos que não são visíveis com telescópios ópticos. Discutimos como o Webb está ajudando a revelar novas informações sobre a formação das primeiras galáxias, estrelas e sistemas planetários, e como ele pode contribuir para a busca de vida em exoplanetas. O artigo destaca as principais descobertas e expectativas associadas a este telescópio inovador', 
'Mariana Lima', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Astronomia'))

INSERT INTO Artigos (data, titulo, conteudo, nome, id_categoria) 
VALUES 
-- Artigo com data única
('2024-01-15T10:00:00', 'A Teoria das Cordas: uma revolução na física', 
'Este artigo explora os fundamentos da Teoria das Cordas, uma proposta revolucionária na física teórica. A teoria sugere que as partículas fundamentais do universo não são pontos, mas sim pequenas cordas vibrantes que oscilam em diferentes modos. Esta visão alternativa tenta unir a mecânica quântica e a relatividade geral, oferecendo uma possível solução para o problema da gravidade quântica. A teoria das cordas também sugere a existência de dimensões adicionais além das conhecidas quatro dimensões do espaço-tempo. Vamos discutir como essa teoria pode resolver problemas antigos e abrir novas possibilidades para a física moderna. A análise abrange desde a origem da teoria até suas implicações para a física de partículas e cosmologia.', 
'Carlos Souza', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Física')),

-- Artigo com data única
('2024-02-20T14:30:00', 'Explorando a Antimatéria: O que é e por que é importante?', 
'A antimatéria é uma das áreas mais fascinantes e misteriosas da física moderna. Quando partículas de antimatéria se encontram com partículas de matéria, elas se aniquilam mutuamente, liberando uma quantidade de energia imensa. Este artigo explora o conceito de antimatéria, como ela é criada e estudada, e o papel que pode desempenhar em futuras tecnologias e na compreensão do universo. Investigamos também como a antimatéria pode ser utilizada em tratamentos médicos e em futuras viagens espaciais.', 
'Ana Oliveira', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Física')),

-- Artigo com a mesma data
('2024-03-01T09:00:00', 'A Origem do Universo: Uma Revisão das Teorias Cosmológicas', 
'Neste artigo, revisamos as principais teorias sobre a origem do universo, desde o Big Bang até teorias mais recentes como o modelo do multiverso. Analisamos como as evidências astronômicas e experimentais sustentam ou contestam essas teorias e discutimos as implicações para o futuro da cosmologia. O artigo também explora como diferentes culturas e tradições entenderam a origem do cosmos e o impacto dessas visões sobre a ciência moderna.', 
'Bruno Lima', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Cosmologia')),

-- Artigo com a mesma data
('2024-03-01T11:00:00', 'Inteligência Artificial e o Futuro da Medicina', 
'A Inteligência Artificial está transformando rapidamente o campo da medicina, oferecendo novas maneiras de diagnosticar, tratar e gerenciar doenças. Este artigo examina as aplicações atuais da IA na medicina, desde diagnósticos automatizados até tratamentos personalizados e robótica cirúrgica. Discutimos também os desafios éticos e técnicos envolvidos na integração da IA na prática médica e o potencial para melhorar os resultados para os pacientes.', 
'Mariana Santos', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Tecnologia')),

-- Artigo com data única
('2024-04-10T16:00:00', 'Mudanças Climáticas e Seus Efeitos na Biodiversidade', 
'As mudanças climáticas estão tendo um impacto significativo sobre a biodiversidade global, afetando habitats, padrões de migração e a sobrevivência de muitas espécies. Este artigo explora como as mudanças no clima estão alterando ecossistemas e quais são as consequências para a fauna e flora. Discutimos também as estratégias para mitigar esses efeitos e promover a conservação da biodiversidade em um mundo em aquecimento.', 
'Lucas Martins', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Meio Ambiente')),

-- Artigo com data única
('2024-05-25T13:00:00', 'O Papel da Física Quântica na Computação do Futuro', 
'A física quântica está abrindo novas fronteiras na ciência da computação, com o desenvolvimento de computadores quânticos que prometem revolucionar a forma como processamos informações. Este artigo explora os princípios básicos da física quântica que são aplicados na computação quântica, como a superposição e o entrelaçamento, e discute as possíveis aplicações e desafios dessa tecnologia emergente. O artigo também examina o impacto potencial da computação quântica em diferentes áreas, como criptografia e inteligência artificial.', 
'Felipe Almeida', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Tecnologia'));

-- Usuários
INSERT INTO Usuarios (nome, email, senha) VALUES
('João Silva', 'joao.silva@example.com', 'senhaDoJoao'),
('Maria Souza', 'maria.souza@example.com', 'Maria123'),
('Carlos Lima', 'carlos.lima@example.com', 'SenhaSecreta');

-- Artigos com usuarios
INSERT INTO Artigos (data, titulo, conteudo, nome, id_categoria, id_usuario) 
VALUES 
('2024-03-10T16:00:00', 'Mudanças Climáticas e Seus Efeitos na Biodiversidade', 
'As mudanças climáticas estão tendo um impacto significativo sobre a biodiversidade global, afetando habitats, padrões de migração e a sobrevivência de muitas espécies. Este artigo explora como as mudanças no clima estão alterando ecossistemas e quais são as consequências para a fauna e flora. Discutimos também as estratégias para mitigar esses efeitos e promover a conservação da biodiversidade em um mundo em aquecimento.', 
'Maria Souza', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Biologia'), 2), -- Maria

('2024-01-15T10:00:00', 'A Teoria das Cordas: uma revolução na física', 
'Este artigo explora os fundamentos da Teoria das Cordas, uma proposta revolucionária na física teórica. A teoria sugere que as partículas fundamentais do universo não são pontos, mas sim pequenas cordas vibrantes que oscilam em diferentes modos. Esta visão alternativa tenta unir a mecânica quântica e a relatividade geral, oferecendo uma possível solução para o problema da gravidade quântica. A teoria das cordas também sugere a existência de dimensões adicionais além das conhecidas quatro dimensões do espaço-tempo. Vamos discutir como essa teoria pode resolver problemas antigos e abrir novas possibilidades para a física moderna. A análise abrange desde a origem da teoria até suas implicações para a física de partículas e cosmologia.', 
'Carlos Souza', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Física'), 3),  -- Carlos

('2024-02-20T14:30:00', 'Explorando a Antimatéria: O que é e por que é importante?', 
'A antimatéria é uma das áreas mais fascinantes e misteriosas da física moderna. Quando partículas de antimatéria se encontram com partículas de matéria, elas se aniquilam mutuamente, liberando uma quantidade de energia imensa. Este artigo explora o conceito de antimatéria, como ela é criada e estudada, e o papel que pode desempenhar em futuras tecnologias e na compreensão do universo. Investigamos também como a antimatéria pode ser utilizada em tratamentos médicos e em futuras viagens espaciais.', 
'Maria Souza', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Física'), 2),  -- Maria

('2024-03-01T09:00:00', 'A Origem do Universo: Uma Revisão das Teorias Cosmológicas', 
'Neste artigo, revisamos as principais teorias sobre a origem do universo, desde o Big Bang até teorias mais recentes como o modelo do multiverso. Analisamos como as evidências astronômicas e experimentais sustentam ou contestam essas teorias e discutimos as implicações para o futuro da cosmologia. O artigo também explora como diferentes culturas e tradições entenderam a origem do cosmos e o impacto dessas visões sobre a ciência moderna.', 
'João Silva', (SELECT id_categoria FROM Categorias WHERE nome_categoria = 'Astronomia'), 1);  -- João

-- Limpar tabelas

USE ConectaCiencia;
GO

-- Apagar os dados de todas as tabelas
DELETE FROM FormularioTema;
DELETE FROM FormularioArtigo;
DELETE FROM Artigos;
DELETE FROM Usuarios;
DELETE FROM Categorias;

-- Reiniciar os IDs das tabelas
DBCC CHECKIDENT ('FormularioTema', RESEED, 0);
DBCC CHECKIDENT ('FormularioArtigo', RESEED, 0);
DBCC CHECKIDENT ('Artigos', RESEED, 0);
DBCC CHECKIDENT ('Usuarios', RESEED, 0);
DBCC CHECKIDENT ('Categorias', RESEED, 0);

-- Verificar
SELECT * FROM FormularioTema;
SELECT * FROM FormularioArtigo;
SELECT * FROM Artigos;
SELECT * FROM Usuarios;
SELECT * FROM Categorias;