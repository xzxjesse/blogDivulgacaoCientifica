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