import { TestBed } from '@angular/core/testing';

import { AvisService } from './avis.service';

describe('AvisService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AvisService = TestBed.get(AvisService);
    expect(service).toBeTruthy();
  });
});
