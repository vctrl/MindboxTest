SELECT a.Theme, t.Name FROM articles a 
LEFT JOIN article_tag at ON a.id = at.article_id
LEFT JOIN tags t ON at.tag_Id = t.id