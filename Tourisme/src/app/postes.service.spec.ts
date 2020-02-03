import { TestBed } from '@angular/core/testing';

import { PostesService } from './postes.service';

describe('PostesService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PostesService = TestBed.get(PostesService);
    expect(service).toBeTruthy();
  });
});
