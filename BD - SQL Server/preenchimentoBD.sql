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

INSERT INTO Artigos (data, titulo, conteudo, nome) 
VALUES 
(GETDATE(), 'A Teoria das Cordas: uma revolução na física', 'Este artigo explora os fundamentos da Teoria das Cordas e seu potencial de unificar as leis da física.', 'Carlos Souza'), 
(GETDATE(), 'A vida artificial e seus impactos futuros', 'Uma investigação sobre como organismos artificiais podem mudar nosso entendimento sobre a vida.', 'Ana Oliveira'),
(GETDATE(), 'A Química e as Mudanças Climáticas', 'Análise de compostos químicos que influenciam diretamente no aquecimento global e suas soluções.', 'João Santos'),
(GETDATE(), 'O Telescópio James Webb: a nova era da astronomia', 'Explorando os avanços proporcionados pelo Telescópio Espacial James Webb na observação do universo.', 'Mariana Lima'),
(GETDATE(), 'Nanotecnologia no tratamento do câncer', 'Como a nanotecnologia está sendo usada para desenvolver novos tratamentos contra o câncer.', 'Pedro Almeida');
